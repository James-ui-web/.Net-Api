using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpdpApi.Api
{
    public class inplayData
    {
    }

    //. class for inplay_filter api

    public class SportObject
    {
        public int success { get; set; }
        public Pager pager { get; set; }
        public SportResult[] results { get; set; }
    }

    public class Pager
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }

    }

    public class SportResult
    {

    public long id { get; set; }
    public long time { get; set; }
    public int time_status { get; set; }
    public League league { get; set; }
    public Team home { get; set; }
    public Team away { get; set; }
    public string ss { get; set; }
    public long our_event_id { get; set; }

    }

    public class League
    {
        public long id { get; set; }
        public string name { get; set; }
    }
    public class Team
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    //. class for inplay_event api
    public class SportEvent
    {
        public int success { get; set; }
        public JArray[] results { get; set; }
        public Stats stats { get; set; }
    }

    public class Stats
    {
        public long event_id { get; set; }
        public long update_at { get; set; }
    }

    //. class for Prematch odds
    public class PreOddRoot
    {
        public int success { get; set; }
        public PreOdd[] results { get; set; }
    }

    public class PreOdd
    {
        public long FI { get; set; }
        public long event_id { get; set; }
        public JObject asian_lines { get; set; }
        public JObject goals { get; set; }
        public JObject main { get; set; }
        public JObject schdule { get; set; }
    }

    //. class for upcoming results
    public class UpComingObject
    {
        public int success { get; set; }
        public Pager pager { get; set; }
        public UpcomingResult[] results { get; set; }
    }

    public class UpcomingResult
    {

        public long id { get; set; }
        public long time { get; set; }
        public int time_status { get; set; }
        public League league { get; set; }
        public Team home { get; set; }
        public Team away { get; set; }
        public string ss { get; set; }
    }

    public class MainContentResult
    {

        public UpcomingResult Upcoming { get; set; }
        public JArray PreOdd { get; set; }
    }
}
