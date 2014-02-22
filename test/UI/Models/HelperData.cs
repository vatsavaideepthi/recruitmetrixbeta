using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class HelperData
    {
        public static void GetCategories(string usertoken)
        {
            AccountCollection allaccounts = new PTAccount().GetUserAccounts(usertoken);

            Business.ApplicationService.AppServiceClient client = new Business.ApplicationService.AppServiceClient();
            client.GetStaticData("expense", "catg", "d7b6fd77f51a46d0ac68e6211f66aebd", usertoken);
        }
    }
}