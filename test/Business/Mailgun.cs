using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace mailgun
{
    public class Mailgun
    {
        public static RestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                 "medien.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "siva <srkrisna@mediennetworks.com>");
           
            request.AddParameter("to", "srkrishna@medien.mailgun.org");
            //request.AddParameter("cc", "charan@mediennetworks.com");
            //request.AddParameter("cc", "scharan@yahoo.com");
            request.AddParameter("subject", "hai hhh");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }

        public static RestResponse SendComplexMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                            "medien.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "siva <srkrisna@mediennetworks.com>");
            //request.AddParameter("to", "srkrishna@mediennetworks.com");
            request.AddParameter("to", "vanam555@gmail.com");
            //request.AddParameter("cc", "charan@mediennetworks.com");
            //request.AddParameter("cc", "scharan@yahoo.com");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.AddParameter("html", "<html>HTML version of the body</html>");
            request.AddFile("attachment", @"C:\Users\Public\Pictures\Sample Pictures\smile.jpg");// Path.Combine("files", "test.jpg"));
            request.AddFile("attachment", @"C:\Users\Public\Pictures\Sample Pictures\Lighthouse.jpg");
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }

        public static RestResponse SendMessageNoTracking()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                          new HttpBasicAuthenticator("api",
                                                     "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                "medien.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "siva <srkrisna@mediennetworks.com>");
            request.AddParameter("to", "vanam555@gmail.com");
            request.AddParameter("subject", "falseHello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.AddParameter("o:tracking", false);
            request.Method = Method.POST;
            return (RestResponse) client.Execute(request);
        }

        public static RestResponse SendTaggedMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                               new HttpBasicAuthenticator("api",
                                                          "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                "medien.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "siva <srkrisna@mediennetworks.com>");
            request.AddParameter("to", "bvlbhargav@gmail.com");
            request.AddParameter("subject", "falseHello");
            request.AddParameter("text", "Testing some Mailgun awesomness!");
            request.AddParameter("o:tag", "September newsletter");
            request.AddParameter("o:tag", "Social");
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }

        public static RestResponse GetStats()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                             new HttpBasicAuthenticator("api",
                                                        "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                  "medien.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/stats";
            request.AddParameter("event", "sent");
            request.AddParameter("event", "opened");
            request.AddParameter("skip", 1);
            request.AddParameter("limit", 2);
            return (RestResponse)client.Execute(request);
        }

        //routing
        public static RestResponse CreateRoute()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator = new HttpBasicAuthenticator("api", "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.Resource = "routes";
            request.AddParameter("priority", 1);
            request.AddParameter("description", "Sample route");
            request.AddParameter("expression",
                                 "match_recipient('.*@medien.mailgun.org')");
            request.AddParameter("action",
                                 "forward('http://myhost.com/messages/')");
            request.AddParameter("action", "stop()");
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }

        //lists
        public static RestResponse CreateMailingList()
        {

            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.Resource = "lists";
            request.AddParameter("address", "ss@medien.mailgun.org");
            request.AddParameter("description", "Mailgun developers list");
            request.Method = Method.POST;
            return (RestResponse)client.Execute(request);
        }
       
        // Add a mailing list member:

        public static RestResponse AddListMember() {
               RestClient client = new RestClient();
               client.BaseUrl = "https://api.mailgun.net/v2";
               client.Authenticator =
                       new HttpBasicAuthenticator("api",
                                                  "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
               RestRequest request = new RestRequest();
               request.Resource = "lists/{list}/members";
               request.AddParameter("list", "srkrishna@mediennetworks.com", ParameterType.UrlSegment);
               request.AddParameter("address", "vanam@gmail.com");
               request.AddParameter("subscribed", true);
               request.AddParameter("name", "sivaram");
               request.AddParameter("description", "Developer");
               request.AddParameter("vars", "{\"age\": 26}");
               request.Method = Method.POST;
               return (RestResponse)client.Execute(request);
        }

      //  Add multiple mailing list members (limit 1,000 per call):
        public static RestResponse AddListMMember() {
        RestClient client = new RestClient();
        client.BaseUrl = "https://api.mailgun.net/v2";
        client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
        RestRequest request = new RestRequest();
        request.Resource = "lists/{list}/members.json";
        request.AddParameter("list", "ss@medien.mailgun.org", ParameterType.UrlSegment);
        request.AddParameter("members", "[{\"address\": \"vanam <vanam555@gmail.com>\", \"vars\": {\"age\": 24}},{\"name\": \"vanamali\", \"address\": \"vanam.malli@gmail.com\", \"vars\": {\"age\": 34}}]");
        request.AddParameter("subscribed", true);
        request.Method = Method.POST;
        return (RestResponse)client.Execute(request);
        }

        //update an existing member:
        public static RestResponse UpdateMember()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.Resource = "lists/{list}/members/{member}";
            request.AddParameter("list", "srkrishna@mediennetworks.com", ParameterType.UrlSegment);
            request.AddParameter("member", "srkrishna@mediennetworks.com", ParameterType.UrlSegment);
            request.AddParameter("subscribed", false);
            request.AddParameter("name", "Foo Bar");
            request.Method = Method.PUT;
            return (RestResponse)client.Execute(request);
        }
        //Listing members:
        public static RestResponse ListingMembers()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.Resource = "lists/{list}/members";
            request.AddParameter("list", "srkrishna@medien.mailgun.org", ParameterType.UrlSegment);
            return (RestResponse)client.Execute(request);
        }
        //Remove a member:
        public static RestResponse RemoveMember()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.Resource = "lists/{list}/members/{member}";
            request.AddParameter("list", "srkrishna@mediennetworks.com", ParameterType.UrlSegment);
            request.AddParameter("member", "vanam555@gmail.com");
            request.Method = Method.DELETE;
            return (RestResponse) client.Execute(request);
        }
        //Remove mailing list:
        public static RestResponse RemoveMailingList()
        {
            RestClient client = new RestClient();
            client.BaseUrl = "https://api.mailgun.net/v2";
            client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "key-57tqhc3m4w46xknvntj7s7ss78ltd7l7");
            RestRequest request = new RestRequest();
            request.Resource = "lists/{list}";
            request.AddParameter("list", "srkrishna@mediennetworks.com", ParameterType.UrlSegment);
            request.Method = Method.DELETE;
            return (RestResponse)client.Execute(request);
        }
    }
}
