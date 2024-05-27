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
        ObservableCollection<User> clients;

        public MainWindow()
        {
            this.DataContext = this;

            

            Role role = new Role() { Name = "Бог" };
            User client = new User() { Name = "лох", Login = "1234", Password = "1234", Role = role };
            Equipment equipment = new Equipment() { Name = "Абоаб" };
            StateRequest stateRequest = new StateRequest() { Name = "Готова" };
            TypeFault typeFault = new TypeFault() { Name = "Жопа" };
            Request request = new Request() {  Equipment = equipment, DateUpdate = DateTime.Now, StateRequest = stateRequest, TypeFault = typeFault, User = client };
            Request request1 = new Request() { Equipment = equipment, DateUpdate = DateTime.Now, StateRequest = stateRequest, TypeFault = typeFault, User = client };



            //clients = new ObservableCollection<Client> (db.Clients.ToList());
            db.Requests.AddRange(request, request1);
            db.SaveChanges();
            InitializeComponent();
            Requests.ItemsSource = db.Requests.ToList();
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new();
            window1.ShowDialog();

            Requests.ItemsSource = db.Requests.ToList();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Request remove = (Request)((Button)sender).DataContext;
            db.Requests.Remove(remove);
            db.SaveChanges();


            Requests.ItemsSource = db.Requests.ToList();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int count = db.Requests.Count(x => x.StateRequest.Name == "Готова");
            MessageBox.Show("Количество выполненных заявок: " + count,"Отчет");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EditingRequest EditingRequest = new();
            EditingRequest.ShowDialog();

            Requests.ItemsSource = db.Requests.ToList();
        }
    }
}