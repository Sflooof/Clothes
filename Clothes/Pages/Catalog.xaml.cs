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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public Catalog()
        {
            InitializeComponent();
            listview_cloth.ItemsSource = App.db.Cloth.ToList();
            //listview_cloth.ItemsSource = clothesEntities.GetContext().Cloth.ToList();
        }

        private void BT_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BT_delete_Click(object sender, RoutedEventArgs e)
        {
            var del_clothes = (sender as Button).DataContext as Entities.Cloth;
            if (MessageBox.Show($"Вы уверены что хотите удалить {del_clothes.name} " +
                $"{del_clothes.manufacturer}?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning)
                == MessageBoxResult.Yes)
            {
                App.db.Cloth.Remove(del_clothes);
                App.db.SaveChanges();
                UpdateClothes();
            }
        }

        private void BT_edit_Click(object sender, RoutedEventArgs e)
        {
            var editCloth = (sender as Button).DataContext as Entities.Cloth;
            NavigationService.Navigate(new Pages.AddEdit(editCloth));
        }
        private void UpdateClothes()
        {
            var update_cloth = App.db.Cloth.ToList();
            //поиск
            update_cloth = update_cloth.Where(x => x.name.ToLower().Contains(TB_find.Text.ToLower())).ToList();           
            listview_cloth.ItemsSource = update_cloth;
            //сортировка по цене 
            if (CB_sort.SelectedIndex == 0)
            {
                update_cloth = update_cloth.OrderBy(x => x.price).ToList();
            }
            else
            {
                update_cloth = update_cloth.OrderByDescending(x => x.price).ToList();
            }
        }

        private void TB_find_TextChanged(TextChangedEventArgs e)
        {

        }

        private void TB_find_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateClothes();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                App.db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                listview_cloth.ItemsSource = App.db.Cloth.ToList();
            }
        }

        private void BT_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddEdit(null));
        }
    }
}
