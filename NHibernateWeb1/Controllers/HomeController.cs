using NHibernateWeb1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NHibernateWeb1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        CustomerDAL _custEntity = null;

        public HomeController()
        {
            _custEntity = new CustomerDAL();
        }

        public ActionResult Index()
        {
            var customers = _custEntity.GetCustomers();

            return View(customers);
        }
    }
}
