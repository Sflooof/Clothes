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

namespace Clothes.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BT_goust_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Catalog());
        }

        private void BT_login_Click(object sender, RoutedEventArgs e)
        {
            var login_user = App.db.User.FirstOrDefault(p => p.login == TB_login.Text && p.password == TB_password.Password);
            if (TB_login.Text == "" || TB_password.Password == "")
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (login_user != null)
            {
                App.CurrentUser = login_user;
                NavigationService.Navigate(new Catalog());
            }
            else
            {
                MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
