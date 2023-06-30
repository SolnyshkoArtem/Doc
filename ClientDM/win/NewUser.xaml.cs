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
using System.Windows.Shapes;

namespace ClientDM.win
{
    /// <summary>
    /// Логика взаимодействия для NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        public NewUser()
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> use = new List<string>();
            use.Add(name.Text);
            use.Add(unit.Text);
            proxy.NewUse(use);
            Close();


        }
    }
}
