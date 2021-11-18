using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfileManager = new UserProfileManager();
        ResidencesManager residencesManager = new ResidencesManager();
        
        public ActionResult Index(string p)
        {
           p = (string)Session["AgentUserName"];
            var profile = userProfileManager.GetAgentByUserName(p);
            return View(profile);
        }

        public ActionResult ResidenceList(string p)
        {
            p = (string)Session["AgentUserName"];
            Context context = new Context();
            int id = context.Agents.Where(x => x.AgentUserName == p).Select(y => y.AgentId).FirstOrDefault();
            var residences = userProfileManager.GetResidenceByAgent(id);
            return View(residences);
        }

        [HttpGet]
        public ActionResult AddNewResidence()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddNewResidence(Residence p)
        {
            residencesManager.ResidencesAddBM(p);
            return RedirectToAction("ResidenceList");
        }

        public ActionResult DeleteResidence(int id)
        {
            residencesManager.DeleteResidencesBM(id);
            return RedirectToAction("ResidenceList");
        }

        [HttpGet]
        public ActionResult UpdateResidence(int id)
        {
            Residence residence = residencesManager.FindResidence(id);
            return View(residence);
        }

        [HttpPost]
        public ActionResult UpdateResidence(Residence p)
        {
            residencesManager.UpdateResidence(p);
            return RedirectToAction("ResidenceList");
        }

        public ActionResult UpdateAgentProfile(Agent p)
        {
            userProfileManager.UpdateAgent(p);
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AgentLogin", "Login");
        }

    }
}