using BLL.Account;
using BLL.Implement;
using MAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Arh.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccount _account;

        public ActionResult delete(int id)
        {
            var data=_account.Delete(id);
            if(data)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult edit(int id)
        {
            var data=_account.GetUsers().Find(x=>x.id==id);
            return View(data);
        }
        [HttpPost]
        public ActionResult edit(Register model)
        {
            var data=_account.Update(model);
            if(data)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public HomeController()
        {
            _account = new AccountService();
        }
        public HomeController(IAccount account)
        {
            _account = account;   
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Register model)
        {
            var data=_account.AddUser(model);
            if(data)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Index()
        {
            var data = _account.GetUsers();
            return View(data);
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