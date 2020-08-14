using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace TpdpApi.Api
{
    public class InplayApi
    {
        private string _base_url = "https://api.b365api.com/v1/bet365/";

        private string _api_url = "";
        private string _token = "";

        public string TOKEN
        {
            get { return _token; }
            set { _token = value; }
        }

        public InplayApi()
        {
            _api_url = _base_url;
            TOKEN = "7792-vfHxdcoJMNwfes";
        }

        public bool getSport(long sport_id, long league, long time, out List<SportResult> results)
        {

            results = new List<SportResult>();

            string url = $"{_api_url}inplay_filter?sport_id={sport_id}&token={TOKEN}";
            if (league != 0)
            {
                url = $"{_api_url}inplay_filter?sport_id={sport_id}&token={TOKEN}&league_id={league}";
            }
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            SportObject w_sportData = JsonConvert.DeserializeObject<SportObject>(response.Content);

            results = w_sportData.results.OfType<SportResult>().ToList();

            //. filter data
            if (time != 0)
            {
                for (int i = results.Count - 1; i >= 0; i--)
                {
                    // Do processing here, then...
                    if (results[i].time > time)
                    {
                        results.RemoveAt(i);
                    }
                }
            }

            return true;
        }

        public bool getEvent(long fixture_id, out List<JArray> results)
        {
            results = new List<JArray>();

            var client = new RestClient($"{_api_url}event?FI={fixture_id}&token={TOKEN}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            SportEvent w_sportData = JsonConvert.DeserializeObject<SportEvent>(response.Content);

            if (w_sportData.success != 1)
            {
                return false;
            }

            results = w_sportData.results.OfType<JArray>().ToList();
            return true;
        }

        public bool getPreOdd(long fixture_id, out JArray results)
        {
            results = new JArray();
            var client = new RestClient($"{_api_url}prematch?FI={fixture_id}&token={TOKEN}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }
            PreOddRoot w_preOddRoot = JsonConvert.DeserializeObject<PreOddRoot>(response.Content);
            results = (JArray)(w_preOddRoot.results[0].main["sp"]["full_time_result"]);
            if (w_preOddRoot.success != 1)
            {
                return false;
            }

            return true;
        }

        public bool getUpcoming(long sport_id, long league, long time, out List<MainContentResult> results)
        {
            results = new List<MainContentResult>();

            string url = $"{_api_url}upcoming?sport_id={sport_id}&token={TOKEN}";
            if (league != 0)
            {
                url = $"{_api_url}upcoming?sport_id={sport_id}&token={TOKEN}&league_id={league}";
            }
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            UpComingObject w_sportData = JsonConvert.DeserializeObject<UpComingObject>(response.Content);

            List<UpcomingResult> w_upcoming = w_sportData.results.OfType<UpcomingResult>().ToList();

            //. filter data
            if (time != 0)
            {
                for (int i = w_upcoming.Count - 1; i >= 0; i--)
                {
                    // Do processing here, then...
                    if (w_upcoming[i].time > time)
                    {
                        w_upcoming.RemoveAt(i);
                    }
                }
            }

            //. join to Prematch Odd
            foreach(UpcomingResult upcoming in w_upcoming)
            {
                MainContentResult item = new MainContentResult();
                JArray preOdd = new JArray();
                getPreOdd(upcoming.id, out preOdd);
                item.Upcoming = upcoming;
                item.PreOdd = preOdd;
                results.Add(item);
            }

            return true;
        }

        public bool getResult(long fixture_id, out JObject results)
        {
            results = new JObject();

            var client = new RestClient($"{_api_url}result?event_id={fixture_id}&token={TOKEN}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            results = JsonConvert.DeserializeObject<JObject>(response.Content);

            if ((string)results["success"] != "1")
            {
                return false;
            }

            return true;
        }
    }
}
