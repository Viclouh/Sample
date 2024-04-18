using Sample.DB;
using Sample.Model;
using Sample.Pages;

using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db = new ApplicationContext();
        ObservableCollection<Client> clients;
        Client client = new Client() {  Name = "123" };
        Client client1 = new Client() {  Name = "234" };
        Client client2 = new Client() { Name = "345" };

        public MainWindow()
        {
            this.DataContext = this;

            InitializeComponent();

            db.Clients.AddRange(client1, client2, client);
            db.SaveChanges();

            clients = new ObservableCollection<Client> (db.Clients.ToList());

            Clients.ItemsSource = clients;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new();
            window1.ShowDialog();
            Clients.ItemsSource = new ObservableCollection<Client>(db.Clients.ToList());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Client remove = (Client)((Button)sender).DataContext;
            db.Clients.Remove(remove);
            db.SaveChanges();

            clients = new ObservableCollection<Client>(db.Clients.ToList());
            Clients.ItemsSource = clients;

        }
    }
}