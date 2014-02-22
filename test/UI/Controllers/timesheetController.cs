using Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UI.Models;
using Business.ApplicationService;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace UI.Controllers
{
    public class timesheetController : Controller
    {
        //
        // GET: /timesheet/

        public ActionResult Index()
        {

            Business.ApplicationService.AppServiceClient appclient = new Business.ApplicationService.AppServiceClient();
            Business.ApplicationService.timesheet timesheet = appclient.Gettimesheet("bf6c010d83ff11e3b03d0019d1a55f95", Session["companyid"].ToString(), Session["userid"].ToString());
            timesheetobj singletimesheet = new timesheetobj();
            singletimesheet.id=timesheet.id;
            singletimesheet.createdon=timesheet.createddate;
            singletimesheet.data=timesheet.data;
            UI.Models.timesheetobj objsheet = Newtonsoft.Json.JsonConvert.DeserializeObject<UI.Models.timesheetobj>(timesheet.data);
            //  UI.Models.timesheetitem tsitem = Newtonsoft.Json.JsonConvert.DeserializeObject<UI.Models.timesheetitem>(tsitems.items.ToString());         
            singletimesheet.company = objsheet.company;
            singletimesheet.client = objsheet.client;        
            singletimesheet.items = objsheet.items;
            singletimesheet.metadata = objsheet.metadata;
            return View(singletimesheet);
        }

        //public List<timesheetitems> GetListMemberswithcontact(string data )
        //{
        //    List<timesheetitem> members = new List<timesheetitem>();
        //    foreach(UI.Models.timesheetitem itemsheet in members)
        //    {
        //    UI.Models.timesheetitem objsheet = Newtonsoft.Json.JsonConvert.DeserializeObject<UI.Models.timesheetitem>(data);
        //    itemsheet.id = objsheet.id;
        //    itemsheet.date = objsheet.date;
        //    itemsheet.overtime = objsheet.overtime;
        //    itemsheet.workhours = objsheet.workhours;
        //    members.Add(itemsheet);
        //    }
        //    return ;

        //}
       //    Business.ApplicationService.timesheet[] timesheets = appclient.Gettimesheets(Session["companyid"].ToString(), Session["userid"].ToString(), "", "", "2013-08-22 12:25:49 ", "2013-08-22 12:25:49");
        //    List<UI.Models.timesheetobj> portaltimesheets = new List<Models.timesheetobj>();
        //    foreach (Business.ApplicationService.timesheet timesheet in timesheets)
        //    {
        //        timesheetobj multimesheet = new timesheetobj();
        //        multimesheet.id = timesheet.id;
        //        multimesheet.createdon = timesheet.createddate;
        //        multimesheet.data = timesheet.data;
        //        UI.Models.timesheetobj objsheet = Newtonsoft.Json.JsonConvert.DeserializeObject<UI.Models.timesheetobj>(timesheet.data);
        //        multimesheet.company = objsheet.company;
        //        multimesheet.client = objsheet.client;
        //        multimesheet.items = objsheet.items;
        //        multimesheet.metadata = objsheet.metadata;
        //        portaltimesheets.Add(multimesheet);
        //    }
        //    return View(portaltimesheets);
        //}

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(timesheet timesheet)
        {
            //UI.Models.timesheetobj time = new Models.timesheetobj();
            //Business.ApplicationService.AppServiceClient appclient = new Business.ApplicationService.AppServiceClient();
            //time.InsertTimesheet(timesheetdata);
            //return RedirectToAction("index", "timesheet", null);
            return View();
        } 

        //public timesheet CreateObject(string XMLString, timesheet YourClassObject)
        //{
        //    XmlSerializer oXmlSerializer = new XmlSerializer(YourClassObject.GetType());
        //    //The StringReader will be the stream holder for the existing XML file 
        //    YourClassObject = (timesheet)oXmlSerializer.Deserialize(new System.IO.StringReader(XMLString));
        //    //initially deserialized, the data is represented by an object without a defined type 
        //    return YourClassObject;
        //}
    }
}