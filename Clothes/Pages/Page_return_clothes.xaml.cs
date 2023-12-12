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
    /// Логика взаимодействия для Page_return_clothes.xaml
    /// </summary>
    public partial class Page_return_clothes : Page
    {
        Cloth _cloth = new Cloth();
        Return_clothes _return_clothes = new Return_clothes();
        public Page_return_clothes(Cloth correct_cloth)
        {
            InitializeComponent();
            if (correct_cloth != null)
            {
                _cloth = correct_cloth;
            }
            DataContext = _cloth;
        }

        public Page_return_clothes(Return_clothes correct_return_clothes)
        {
            InitializeComponent();
            _return_clothes = correct_return_clothes;
            DataContext = _return_clothes;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrEmpty(TB_description.Text))
            {
                errors.AppendLine("Введите причину возврата");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var return_cl = new Return_clothes
                {                    
                    clothes_return = _cloth.Id_cloth,
                    user_return = App.CurrentUser.Id_user,
                    description = TB_description.Text
                };
                
            
            try
            {
                App.db.Return_clothes.Add(return_cl);
                App.db.SaveChanges();
                MessageBox.Show("Заявка оставлена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            NavigationService.GoBack(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
