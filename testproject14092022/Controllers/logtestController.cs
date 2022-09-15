using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Security.Cryptography.X509Certificates;

namespace testproject14092022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class logtestController : ControllerBase


       
    {
        //global log dependency injection
        //private readonly ILogger<logtestController> _logger;


        //public logtestController(ILogger<logtestController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("test")]
        public string test()
        {

            // global log
            // _logger.LogInformation("get api");


            //custom log
           // Log.Information("event name module:2");


            try
            {
                //Logclass data = new Logclass();

                List<Logclass> list = new List<Logclass>();
                //data = logfunction();
                list = test2();
                foreach (var check in list)
                {

                    Log.Information($"{check.eventname}\r\n{check.module}\r\n{check.apiurl}");
                }
                
                //Log.Information($"{data.eventname}\r\n{data.module}\r\n{data.apiurl}");



                //for(int i = 0; i < 100; i++)
                //{
                //    if(i==56)
                //    {
                //        throw new Exception("  this is demo exception  ");
                //    }
                //    else
                //    {  
                //        Log.Information("the value of i is    {i}   ",i);
                //    }
                //}
                
              
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }


            return "test";
        
        }
        [HttpGet("test1")]
        public string test1()
        {
            Log.Information("get api test1");

            return "test1";
        }
        [HttpGet("hello")]

        public List<Logclass> test2()
        //public Logclass logfunction()
        {
            List<Logclass> list = new List<Logclass>();
            //list[0].eventname = "create";
            //list[0].module = "Get";
            //list[0].apiurl = "api/logtest/test";

            //list[1].eventname = "update";
            //list[1].module = "put";
            //list[1].apiurl = "api/logtest/put";

            //list[2].eventname = "delete";
            //list[2].module = "Delete";
            //list[2].apiurl = "api/logtest/delete";

            Logclass data = new Logclass()
            {
                eventname = "create",
                module = "Get",
                apiurl = "api/logtest/test"

            };
            Logclass data1 = new Logclass()
            {
                eventname = "update",
                module = "put",
                apiurl = "api/logtest/update"

            };



            list.Add(data);
            list.Add(data1);


            Console.WriteLine(list);
            return list;
        }


        public class Logclass
        {
            public string eventname { get; set; }
            public string module { get; set; }
            public string  apiurl { get; set; }
         }
    }
}
