using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace JobTest.Models
{
    public class Job
    {
        public string client { get; set; }
        [JsonProperty(PropertyName = "job-number")]
        public int jobnumber { get; set; }
        [JsonProperty(PropertyName = "job-name")]
        public string jobname { get; set; }
        public DateTime due { get; set; }
        public string status { get; set; }
    }

public class RootObject
    {
        public List<Job> jobs { get; set; }
    }
}