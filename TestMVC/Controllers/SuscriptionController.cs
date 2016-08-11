using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class SuscriptionController : Controller
    {
        // GET: Suscription
        public JsonResult Index()
        {
            IList<SuscriptionModel> suscriptions;
            ISessionFactory factory =
      new NHibernate.Cfg.Configuration().Configure().BuildSessionFactory();
         
            using (ISession session = factory.OpenSession())
            {
                suscriptions = (IList<SuscriptionModel>)session.QueryOver<SuscriptionModel>().List(); 
                session.Flush();
                session.Close();
            }
            factory.Close();

            return Json(suscriptions, JsonRequestBehavior.AllowGet);
        }
    }
}