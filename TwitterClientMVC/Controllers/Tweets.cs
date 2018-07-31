using Newtonsoft.Json;
using System.Collections.Generic;

namespace TwitterClientMVC.Controllers
{

    public class Tweets
    {
        public Tweet response;
    }

    public class Tweet
    {
        [JsonProperty("numFound")]
        public int NumFound { get; set; }
        [JsonProperty("start")]
        public int StartNum { get; set; }
        [JsonProperty("docs")]
        public doc[] docs { get; set; }
    }

    public class doc
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("abstract")]
        public string[] Abstract { get; set; }        
    } 
}


  //  public class Tweet
  //  {
  //      [JsonProperty("abstract")]
  //      public string Abstract { get; set; }
  //      //public string Abstract = "abstract";
  //      [JsonProperty("id")]
  //      public string Id { get; set; }
     
  //}
