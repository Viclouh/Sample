using Sample.Model;
using Sample.DB;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ApplicationContext = Sample.DB.ApplicationContext;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Sample.Pages
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ApplicationContext db = new ApplicationContext();
        public Window1()
        {
            this.DataContext = this;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Client client = new Client() {Name = Saske.Text };
            try
            {
                db.Clients.Add(client);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
