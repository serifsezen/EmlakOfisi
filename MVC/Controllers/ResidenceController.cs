using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ResidenceController : Controller
    {
        ResidencesManager residencesManager = new ResidencesManager();
        // GET: Residence
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult ResidenceList()
        {
            var residenceList = residencesManager.GetAll();
            return View(residenceList);
        }
       
        

       

    }
}