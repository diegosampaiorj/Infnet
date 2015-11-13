using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GasSensor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return SendMail();
        }

        // GET: Home
        public ActionResult SendMail()
        {
            return View();
        }
    }
}