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

         public ActionResult Index(string q, string S)
         {
             string file = Server.MapPath("~/App_Data/jobs.json");

             //deserialie JSON from file
             string Json = System.IO.File.ReadAllText(file);
             JavaScriptSerializer jss = new JavaScriptSerializer();
             //var data = jss.Deserialize<RootObject>(Json);
             var data = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(Json);
             var jobs = (from j in data.jobs
                         select j);

             int id = Convert.ToInt32(Request["SearchType"]);
             var searchParameter = "Searching";
      

             if (!string.IsNullOrWhiteSpace(q))
             {
                 switch (id)
                 {
                     case 0:
                         int iQ = Convert.ToInt32(q);
                         jobs = jobs.Where(j => j.jobnumber.Equals(iQ));
                         searchParameter += " Job Number for ' " + q + " '";
                         break;
                     case 1:
                         jobs = jobs.Where(j => j.client.Contains(q));
                         searchParameter += " Clent for ' " + q + " '";
                         break;
                     case 2:
                         jobs = jobs.Where(j => j.jobname.Contains(q));
                         searchParameter += " Job Name for '" + q + "'";
                         break;
                     case 3:
                         DateTime duedate = Convert.ToDateTime(q);
                         jobs = jobs.Where(j => j.due.Equals(duedate));
                         searchParameter += " Due Date for '" + q + "'";
                         break;
                     case 4:
                         jobs = jobs.Where(j => j.status.Contains(q));
                         searchParameter += " Status for '" + q + "'";
                         break;
                 }
             }
             else
             {
                 searchParameter += "ALL";
             }
             ViewBag.SearchParameter = searchParameter;
             return View(jobs);
         }



    }
}
