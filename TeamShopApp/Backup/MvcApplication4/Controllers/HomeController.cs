using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Repository;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork uow = new UnitOfWork(new SQLServerContext("DefaultConnection"));
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult InsertTovar()
        {
            return View(new Tovar());
        }
        [HttpPost]
        public ActionResult InsertTovar(Tovar tovar)
        {
            uow.Tovars.Create(tovar);
            uow.Save();
            return View(new Tovar());
        }
        [HttpGet]
        public ActionResult InsertOrder()
        {
            return View(new Order());
        }
        [HttpPost]
        public ActionResult InsertOrder(Order order)
        {
            uow.Orders.Create(order);
            uow.Save();
            return View(new Order());
        }
        public ActionResult ViewTovar()
        {
            return View(uow.Tovars.GetAll());
        }
        public ActionResult ViewOrder()
        {
            return View(uow.Orders.GetAll());
        }
    }
}
