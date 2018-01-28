using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth2onFB.Controllers
{
    public class HomeController : Controller
    {
        private string clientID = "1182536621783653";
        private string redirectURI = "http://localhost:3990/succes";
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ViewBag.URL = getAuthURL();

            return View();
        }


        private string getAuthURL()
        {
            return "https://www.facebook.com/dialog/oauth?client_id=" + clientID + "&redirect_uri=" + redirectURI;
        }
    }
}
