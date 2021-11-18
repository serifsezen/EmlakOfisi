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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult AgentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgentLogin(Agent p)
        {
            Context contex = new Context();
            var userInfo = contex.Agents.FirstOrDefault(x => x.AgentUserName == p.AgentUserName && x.AgentPassword == p.AgentPassword);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.AgentUserName, false);
                Session["AgentUserName"] = userInfo.AgentUserName.ToString();
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("AgentLogin", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            Context contex = new Context();
            var admininfo = contex.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.AdminPassword == p.AdminPassword);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["UserName"] = admininfo.UserName.ToString();
                return RedirectToAction("AgentList", "Agent");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }

    }
}