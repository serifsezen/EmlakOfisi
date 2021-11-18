using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManager adminManager = new AdminManager();
        public ActionResult Index()
        {
            var adminler = adminManager.GetAll();
            return View(adminler);
        }
        
    }
}