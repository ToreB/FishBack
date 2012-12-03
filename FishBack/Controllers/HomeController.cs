using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using System.Web.Mvc;
using FishBack.DataAccess;
using FishBack.Domain;

namespace FishBack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dictionary = new Dictionary<string, object>();

            using (var db = new FishDbContext())
            {
                dictionary.Add("FishEvent", db.FishEvents.FirstOrDefault());
                dictionary.Add("User", db.Users.FirstOrDefault());
                dictionary.Add("BlogEntry", db.BlogEntries.FirstOrDefault());
            }

            return View(dictionary);
        }
    }
}
