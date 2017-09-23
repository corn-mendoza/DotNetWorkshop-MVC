using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetWorkshopSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var _index = Environment.GetEnvironmentVariable("INSTANCE_INDEX");
            if (_index == null)
            {
                _index = "Running Local";
            }

            var _prodmode = Environment.GetEnvironmentVariable("PROD_MODE");
            if (_prodmode == null)
            {
                _prodmode = "Development";
            }

            var _port = Environment.GetEnvironmentVariable("PORT");
            if (_port == null)
            {
                _port = "localhost";
            }

            ViewBag.Index = $"Application Index: {_index}";
            ViewBag.ProdMode = $"Production Mode: {_prodmode}";
            ViewBag.Port = $"Port: {_port}";
            ViewBag.Uptime = $"Uptime: {DateTime.Now.Subtract(TimeSpan.FromMilliseconds(Environment.TickCount)).ToString() }";
            ViewBag.WorkshopUrl = Environment.GetEnvironmentVariable("WORKSHOP_URL");
            return View();
        }
        public ActionResult KillMe()
        {
            Environment.Exit(-1);

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Workshop Commands";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Platform Architect contact info.";

            return View();
        }
    }
}