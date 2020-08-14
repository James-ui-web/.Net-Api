using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TpdpApi.Models;
using TpdpApi.Api;
using RestSharp;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TpdpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class getSport : ControllerBase
    {
        InplayApi api = new InplayApi();

            //. GET: api/<getSport>
            [HttpGet]
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            //. GET api/<getSprot>/5
            [HttpGet("{id}")]
            public IActionResult Get(long id, long league,long time, string token)
            { 
                List<SportResult> results;
                if(token != null)
                {
                    api.TOKEN = token;
                }

                bool status = api.getSport(id, league,time, out results);

                if (status == false)
                         {
                             return NotFound();
                         }
         
                return Ok(results);
             }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class getEvent : ControllerBase
    {
        InplayApi api = new InplayApi();
        
        //. GET api/<getEvent>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id, string token)
        {
            List<JArray> results;
            if (token != null)
            {
                api.TOKEN = token;
            }

            bool status = api.getEvent(id, out results);

            if (status == false)
            {
                return NotFound();
            }

            return Ok(results);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class getPreOdd : ControllerBase
    {
        InplayApi api = new InplayApi();

        //. GET api/<getEvent>/5
        [HttpGet]
        public IActionResult Get(long id, string token)
        {
            JArray results;
            if (token != null)
            {
                api.TOKEN = token;
            }

            bool status = api.getPreOdd(id, out results);

            if (status == false)
            {
                return NotFound();
            }

            return Ok(results);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class getUpcoming : ControllerBase
    {
        InplayApi api = new InplayApi();

        //. GET api/<getEvent>/5
        [HttpGet]
        public IActionResult Get(long id, long league, long time, string token)
        {
            List<MainContentResult> results;
            if (token != null)
            {
                api.TOKEN = token;
            }

            bool status = api.getUpcoming(id, league, time, out results);

            if (status == false)
            {
                return NotFound();
            }

            return Ok(results);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class getResult : ControllerBase
    {
        InplayApi api = new InplayApi();

        //. GET api/<getResult>
        [HttpGet("{id}")]
        public IActionResult Get(long id, string token)
        {
            JObject results;
            if (token != null)
            {
                api.TOKEN = token;
            }

            bool status = api.getResult(id, out results);

            if (status == false)
            {
                return NotFound();
            }

            return Ok(results);
        }
    }
}
