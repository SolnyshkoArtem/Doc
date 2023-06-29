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

namespace ClientDM.win
{
    /// <summary>
    /// Логика взаимодействия для cho.xaml
    /// </summary>
    public partial class cho : Page
    {
        public cho()
        {
            InitializeComponent();
        }

        private void btnDoc_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new doc());
        }

        private void btnNewDoc_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new dobav());
        }

        private void g(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
