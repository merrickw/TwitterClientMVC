using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TwitterClientMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //"http://search.twitter.com/search.json?q=pluralsight"
            string url = "http://api.plos.org/search?q=title:DNA&fl=id,abstract&wt=json";

            Tweets model = null;  // Tweets contains a Tweet object called response
                                  // model.response is a tweet object containing .NumFound, .StartNum, and .docs[]

            var client = new HttpClient();
            var task = client.GetAsync(url)
                .ContinueWith((taskwithresponse) => 
                {
                    var response = taskwithresponse.Result;
                    var readtask = response.Content.ReadAsAsync<Tweets>();
                    readtask.Wait();
                    model = readtask.Result;  // model is an object that contains an object (Tweet) which contains the array of docs
                });
            task.Wait();

            return View(model.response.docs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}