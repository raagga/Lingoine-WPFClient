using Lingoine.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lingoine.Views
{
    /// <summary>
    /// Interaction logic for LanguageSelect.xaml
    /// </summary>
    public partial class LanguageSelect : Page
    {
        public LanguageSelect()
        {
            InitializeComponent();

            var client = new RestClient(Constants.requestUrl);
            var request = new RestRequest("api/LanguageTables/", Method.GET);
            var queryResultList = client.Execute<List<Models.Language>>(request).Data;
            queryResultList.ForEach( delegate(Models.Language lang)
            {
                langSelect.Items.Add(lang.LanguageName);
            });
            this.UpdateLayout();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainScreen());
        }

        private void submitLang_Click(object sender, RoutedEventArgs e)
        {
            Models.UserLanguage userLang = new Models.UserLanguage();
            Models.User currUser = (Models.User)App.Current.Properties["User"];
            userLang.UserEmail = currUser.Email;

            var client = new RestClient(Constants.requestUrl);
            var request = new RestRequest("api/LanguageTables/", Method.GET);
            var queryResultList = client.Execute<List<Models.Language>>(request).Data;
            string currLang = langSelect.SelectedItem.ToString();
            queryResultList.ForEach(delegate (Models.Language lang)
            {
                if (lang.LanguageName == currLang)
                {
                    userLang.LanguageId = lang.Id;
                }
            });

            request = new RestRequest("api/UserLanguageTables", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(userLang);
            var response = client.Execute(request);
            System.Diagnostics.Debug.WriteLine(response.Content);
            this.NavigationService.Navigate(new ChooseLanguage());
        }

        private void nextLang_Click(object sender, RoutedEventArgs e)
        {
            Models.UserLanguage userLang = new Models.UserLanguage();
            Models.User currUser = (Models.User)App.Current.Properties["User"];
            userLang.UserEmail = currUser.Email;

            var client = new RestClient(Constants.requestUrl);
            var request = new RestRequest("api/LanguageTables/", Method.GET);
            var queryResultList = client.Execute<List<Models.Language>>(request).Data;
            string currLang = langSelect.SelectedItem.ToString();
            queryResultList.ForEach(delegate (Models.Language lang)
            {
                if (lang.LanguageName == currLang)
                {
                    userLang.LanguageId = lang.Id;
                }
            });

            request = new RestRequest("api/UserLanguageTables", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(userLang);
            var response = client.Execute(request);
            System.Diagnostics.Debug.WriteLine(response.Content);
            this.NavigationService.Navigate(new LanguageSelect());
        }
    }
}
