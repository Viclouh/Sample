using Sample.DB;
using Sample.Model;
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
using System.Windows.Shapes;

namespace Sample.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        ApplicationContext db = new ApplicationContext();
        public Auth()
        {
            InitializeComponent();
            User client = new User() { Name = "123", Login = "1234", Password = "1234",RoleId = 1 };


            Role role = new Role() {Name = "Бог"};

            db.Roles.Add(role);
            db.Users.AddRange( client);
            db.SaveChanges();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Login.Text == "" || Password.Text == "") 
                {
                    MessageBox.Show("Заполните поля");
                }
                if (ValidateCredentials(Login.Text, Password.Text))
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Неверные данные");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }
        private bool ValidateCredentials(string login, string password)
        {
            return db.Users.First(x => x.Login == login && x.Password == password) != null;
        }
    }
}
