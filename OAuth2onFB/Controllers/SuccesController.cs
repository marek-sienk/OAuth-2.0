using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace OAuth2onFB.Controllers
{
    public class SuccesController : Controller
    {
        private string clientID = "1182536621783653";
        private string clientSecret = "3035c26b01908bfc80d71866bd8d856f";
        private string redirectURI = "http://localhost:3990/succes";
        //
        // GET: /Succes/
        public ActionResult Index(string code)
        {
            string graphUrl = getGraphURL(code);

            string accesToken = getAccesToken(graphUrl);

            string g = "https://graph.facebook.com/me?" + accesToken;

            string graph = getGraph(g);

            //string graph1 = getGraph("https://graph.facebook.com/1182536621783653?" + accesToken);
            //ViewBag.code = graph1;

            ViewBag.code = getData(graph);

            return View();
        }

        private string getGraphURL(string code)
        {
            return "https://graph.facebook.com/oauth/access_token?client_id=" + clientID + "&redirect_uri=" + redirectURI
                    + "&client_secret=" + clientSecret + "&code=" + code;
        }

        private string getAccesToken(string url)
        {
            string s;
            using (var client = new WebClient())
            {
                s = client.DownloadString(url);
            }
            return s;
        }

        private string getGraph(string url)
        {
            string s;
            using (var client = new WebClient())
            {
                s = client.DownloadString(url);
            }
            return s;
        }

        private string getData(string graph)
        {
            string[] s = graph.Split(',').Where(Char.IsLetter).ToArray();

            string info = "Jestes zalogowany jako " + graph.Split(',')[0].Split(':')[1] +
                " Twoje id to " + graph.Split(',')[1].Split(':')[1];
            Regex rgx = new Regex("[^a-zA-Z0-9 -(]");
            info = rgx.Replace(info, "");

            return info;
        }
	}
}