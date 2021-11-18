using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AgentController : Controller
    {
        AgentManager agentManager = new AgentManager();
        // GET: Agent
        public ActionResult Index()
        {
    
            return View();
        }
        public ActionResult AgentList()
        {
            var agentList = agentManager.GetAll();
            return View(agentList);
        }

        [HttpGet]
        public ActionResult AddNewAgent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewAgent(Agent p)
        {
            agentManager.AddNewAgentBM(p);
            return RedirectToAction("AgentList");
        }

        

    }
}