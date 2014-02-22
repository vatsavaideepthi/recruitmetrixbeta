using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Users/

        public ActionResult Index()
        {
            Business.ApplicationService.AppServiceClient appclient = new Business.ApplicationService.AppServiceClient();
            List<Business.ApplicationService.appuser> allusers = new List<Business.ApplicationService.appuser>();
            List<Business.ApplicationService.appuser> admins = new List<Business.ApplicationService.appuser>();
            admins = appclient.GetAdmins(Session["companyid"].ToString(), "comadmin", Session["usertoken"].ToString()).ToList();

            List<Business.ApplicationService.appuser> recruiters = new List<Business.ApplicationService.appuser>();
            recruiters = appclient.GetAdmins(Session["companyid"].ToString(), "comrecruit", Session["usertoken"].ToString()).ToList();
            admins.AddRange(recruiters);

            return View(admins);
        }

        [HttpGet]
        public ActionResult admin()
        {
            return View();
        }
        [HttpGet]
        public ActionResult recruiter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult admin(UI.Models.portaluser admindata)
        {
            Business.ApplicationService.AppServiceClient appclient = new Business.ApplicationService.AppServiceClient();
            appclient.AddAdmin(admindata.usermail, admindata.userpassword, admindata.usertitle, Session["usertoken"].ToString());

            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult recruiter(UI.Models.portaluser recruiterdata)
        {
            Business.ApplicationService.AppServiceClient appclient = new Business.ApplicationService.AppServiceClient();
            appclient.AddRecruiter(recruiterdata.usermail, recruiterdata.userpassword, recruiterdata.usertitle, Session["usertoken"].ToString());

            return RedirectToAction("index");
        }

    }
}
