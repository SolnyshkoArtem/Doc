using FDocmanInter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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

namespace ClientDM.win
{
    /// <summary>
    /// Логика взаимодействия для dobav.xaml
    /// </summary>
    public partial class dobav : Page
    {
        ChannelFactory<IDocService> channelFactory;
        IDocService proxy;
        string put;
        List<object> objects = new List<object>();
        Dictionary<string, int> keyValuePairs= new Dictionary<string, int>();
        DealFiles deal = new DealFiles();
        string filenames;
        public dobav()
        {
            InitializeComponent();
            channelFactory = new ChannelFactory<IDocService>("DocManServiceEndPoint");
            proxy = channelFactory.CreateChannel();
            keyValuePairs = proxy.GetUser();
        }

        private void btnAdd_click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(suble.Text))
                errors.AppendLine("Введите название письма!");
            if (string.IsNullOrWhiteSpace(from.Text))
                errors.AppendLine("Введите отправителя!");
            if (string.IsNullOrWhiteSpace(pol.Text))
                errors.AppendLine("Выберите получателя!");
            if (string.IsNullOrWhiteSpace(krat.Text))
                errors.AppendLine("Введите краткое описание письма!");
            if (string.IsNullOrWhiteSpace(rec.Text))
                errors.AppendLine("Введите дату получения!");
            if (string.IsNullOrWhiteSpace(exp.Text))
                errors.AppendLine("Введите крайнюю дату ответа!");


            if (errors.Length == 1)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!");
                return;
            }
            else if (errors.Length > 1)
            {
                MessageBox.Show(errors.ToString(), "Ошибки!");
                return;
            }


            int r;
            objects.Add(suble.Text);
            objects.Add(krat.Text);
            objects.Add(from.Text);
            
            objects.Add(pol.Text);
            objects.Add((DateTime)rec.SelectedDate);
            objects.Add((DateTime)exp.SelectedDate);

            put = deal.newLetter(filenames, Convert.ToString(objects[0]));
            objects.Add("На обработке");
            objects.Add(put);
            objects.Add("");


                proxy.NewLetter(objects);
                MessageBox.Show("Письмо добавлено!", "Оповещение!");
                NavigationService.Navigate(new doc());   
        }
        
        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {
            
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".pdf"; // Default file extension
            dialog.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filenames = dialog.FileName;
                
            }
            

        }
    }
}
