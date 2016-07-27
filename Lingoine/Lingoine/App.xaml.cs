using Lingoine.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lingoine
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            App.Current.Properties["UserLevel"] = "0";
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Models.User currUser = (Models.User)App.Current.Properties["User"];
            var client = new RestClient(Constants.requestUrl);
            var request = new RestRequest("api/UserTables/" + currUser.Email + "/0/", Method.GET);
            var response = client.Execute(request);
        }
    }
}
