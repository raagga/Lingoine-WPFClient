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
    /// Interaction logic for RatingScreen.xaml
    /// </summary>
    public partial class RatingScreen : Page
    {
        public RatingScreen()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if(radioButton1.IsChecked.ToString() == "True" ||
                radioButton2.IsChecked.ToString() == "True" ||
                radioButton3.IsChecked.ToString() == "True" ||
                radioButton4.IsChecked.ToString() == "True" ||
                radioButton5.IsChecked.ToString() == "True")
            {
                this.NavigationService.Navigate(new MainScreen());
            }
            else
            {
                Alert.Text = "We appreciate your feedback :) Please choose your response";
            }
            
        }
    }
}
