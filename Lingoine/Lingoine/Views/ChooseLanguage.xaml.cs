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
            langSelect.Items.Add("French");
            langSelect.Items.Add("German");
            this.UpdateLayout();
        }

        private void choose_Click(object sender, RoutedEventArgs e)
        {
            string selectedLanguage = langSelect.SelectedItem.ToString();
            App.Current.Properties["Language"] = selectedLanguage;
            this.NavigationService.Navigate(new MainScreen());
        }
    }
}
