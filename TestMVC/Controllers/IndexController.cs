using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMVC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Mensaje = "This will be overwritten.";
            return View("View");
        }
        // GET: Example
        public string Example(string a, string b)
        {
            return a + " / " + b;
        }
        [HttpPost]
        public string Post()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string stream = new StreamReader(req).ReadToEnd();

            return stream;
        }
    }
}