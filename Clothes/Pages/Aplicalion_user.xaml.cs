using Clothes.Entities;
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
    /// Логика взаимодействия для Aplicalion_user.xaml
    /// </summary>
    public partial class Aplicalion_user : Page
    {
        public Aplicalion_user()
        {
            InitializeComponent();
            listview_cloth.ItemsSource = App.db.Return_clothes.ToList();
        }

        private void BT_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var delete = (sender as Button).DataContext as Return_clothes;
            if (MessageBox.Show($"Вы действительно хотите удалить заявку номер {delete.Id_return}?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.db.Return_clothes.Remove(delete);
                App.db.SaveChanges();
                listview_cloth.ItemsSource = App.db.Return_clothes.ToList();
            }
        }
    }
}
