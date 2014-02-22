using Business;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using UI.Controllers;

namespace UI.Models
{

    public class timesheetobj : BaseObject
    {
        public string createdon { get; set; }
        public string ownerid { get; set; }
        public string ownername { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
        public company company { get; set; }
        public client client { get; set; }
        public self self { get; set; }
        public timesheetmetadata metadata { get; set; }
        public timesheetitems items { get; set; }
        public string data { get; set; }


        //public string InsertTimesheet(timesheetobj timesheets)
        //{
        //    try
        //    {
        //        Business.ApplicationService.AppServiceClient appclient = new Business.ApplicationService.AppServiceClient();
        //        timesheets.data = Newtonsoft.Json.JsonConvert.SerializeObject(timesheets);
        //        string timesheetid = appclient.CreateTimesheet(timesheets.ownerid, "", timesheets.company.id, timesheets.company.title, timesheets.client.id, timesheets.client.title, 0, startdate, enddate, timesheets.data);
        //        return timesheetid;
        //    }

        //    catch { throw; }

        //} //with mv

        }
    }


   
