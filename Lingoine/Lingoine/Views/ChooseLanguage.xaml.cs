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
    /// Interaction logic for ChooseLanguage.xaml
    /// </summary>
    public partial class ChooseLanguage : Page
    {
        public ChooseLanguage()
        {
            InitializeComponent();
            //TODO: Find available language
            Models.User currUser = (Models.User)App.Current.Properties["User"];
            string currUserEmail = currUser.Email;

            var client = new RestClient(Constants.requestUrl);
            var request1 = new RestRequest("api/UserLanguageTables/" + currUserEmail, Method.GET);
            var userLanguageList = client.Execute<List<Models.UserLanguage>>(request1).Data;

            var request2 = new RestRequest("api/LanguageTables/", Method.GET);
            var languageList = client.Execute<List<Models.Language>>(request2).Data;

            userLanguageList.ForEach(delegate (Models.UserLanguage userLanguage)
            {
                string toAddLang = string.Empty;
                languageList.ForEach(delegate (Models.Language language) 
                {
                    if (language.Id == userLanguage.LanguageId)
                    {
                        toAddLang = language.LanguageName;
                    }
                });
                langSelect.Items.Add(toAddLang);
            });
            this.UpdateLayout();
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedLanguage = langSelect.SelectedItem.ToString();
                App.Current.Properties["Language"] = selectedLanguage;
                this.NavigationService.Navigate(new MainScreen());
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex);
                ErrorBox.Text = "Please select a language";
            }
        }
    }
}
