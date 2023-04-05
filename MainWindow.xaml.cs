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
using WpfApp4.Model;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        private Task1TestDBEntities _db = new Task1TestDBEntities();
        public MainWindow()
        {
            InitializeComponent();

            DGUserInfo.ItemsSource = _db.Users.ToList(); 
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User userModel = _db.Users.FirstOrDefault(eat => eat.Login == TbLogin.Text && eat.Password == PBPassword.Password);
                if (userModel != null)
                {
                    MessageBox.Show($"Login - {userModel.Login}");

                    TbLogin.Text = string.Empty;
                    PBPassword.Password = string.Empty;
                }
                else
                {
                    MessageBox.Show($"HET!");

                }
            }
            catch (Exception)
            {

                throw;
            }
       }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TbLogin1.Text) || 
                    string.IsNullOrEmpty(PBPassword1.Password))
                {
                    MessageBox.Show($"HET!");
                }
                else
                {
                    _db.Users.Add(new User()
                    {
                        Login = TbLogin1.Text,
                        Password = PBPassword1.Password
                    });
                    _db.SaveChanges();
                    MessageBox.Show($"DA!");
                    DGUserInfo.ItemsSource = _db.Users.ToList();

                    TbLogin1.Text = string.Empty;
                    PBPassword1.Password = string.Empty;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
