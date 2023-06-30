using ClientDM.win;
using FDocmanInter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace ClientDM
{
    /// <summary>
    /// Логика взаимодействия для page.xaml
    /// </summary>
    public partial class page : Page
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        public page()
        {
            InitializeComponent();
            //client = new ServiceDocMa.ServiceDocManClient(new System.ServiceModel.InstanceContext(this));
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
        }

        public void CallBack(string k)
        {
            
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            int a;
            if(log.Text == "Администратор")
            {
                NavigationService.Navigate(new Admin());
            }
            else
            {

            try
            {
                a = proxy.GetIDToEnter(log.Text);
                if (a > 0)
                {
                    NavigationService.Navigate(new nach(a));
                }
                else if (a == 0)
                {
                    NavigationService.Navigate(new cho());
                }
                else MessageBox.Show("Неправильно введен логин!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new cho());
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //client = new ServiceDocMa.ServiceDocManClient(new System.ServiceModel.InstanceContext(this));
        }
    }
}
