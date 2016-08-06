using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using JobTest.Models;

namespace JobTest.Controllers
{
    public class JobsController : Controller
    {
        //
        // GET: /Jobs/
         [HttpGet]
        public ActionResult Index()
        {

            string file = Server.MapPath("~/App_Data/jobs.json");

            //deserialie JSON from file
            string Json = System.IO.File.ReadAllText(file);
             JavaScriptSerializer jss = new JavaScriptSerializer();
             //var data = jss.Deserialize<RootObject>(Json);
             var data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(Json);
             var list = (from c in data.jobs
                         select c);
             return View(list);
        }

         [HttpPost]
         public ActionResult Index(string SearchKey)
         {

             string file = Server.MapPath("~/App_Data/jobs.json");

             //deserialie JSON from file
             string Json = System.IO.File.ReadAllText(file);
             JavaScriptSerializer jss = new JavaScriptSerializer();
             //var data = jss.Deserialize<RootObject>(Json);
             var data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(Json);
             var list = (from c in data.jobs
                         where (c.client + ' ' + c.jobnumber.ToString() + ' ' + c.jobname + ' ' + c.status).Contains(SearchKey)
                        // where c.client.Contains(SearchKey) 
                         select c);

           
             return View(list);
         }

        // public List<Job> JobsData(string SearchKey)
        //{
        //    List<Job> jobs = new List<Job>();
        //    string file = Server.MapPath("~/App_Data/jobs.json");

        //    deserialie JSON from file
        //    string Json = System.IO.File.ReadAllText(file);
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    var data = jss.Deserialize<RootObject>(Json);
        //    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(Json);
        //    var jobsitem = from c in data.jobs 
        //                where SearchKey == "" ? true : 
        //                c.client.Contains(SearchKey)
        //                select c;
        //    foreach (var item in jobsitem)
        //    {
        //        jobs.Add(new Job{
        //            client = item.client,
        //            jobnumber = item.jobnumber,
        //            jobname = item.jobname,
        //            due = item.due,
        //            status = item.status
                   
        //        });

              
        //    }
        //    return jobs;
          
        //}

    }
}
