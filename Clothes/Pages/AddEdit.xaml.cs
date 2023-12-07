using Clothes.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Page
    {
        private Cloth _curCloth = new Cloth();
        private byte[] img = null;
        public AddEdit(Cloth curCloth)
        {
            
            InitializeComponent();
            FillComboBox();

            if (curCloth != null)
                _curCloth = curCloth;

            DataContext =_curCloth;
        }

        private void FillComboBox()
        {
            foreach (var item in App.db.Color.ToList()) 
            {
                CB_color.Items.Add(item.name);
            }
            var _curColor = App.db.Color.FirstOrDefault(x => x.Id_color == _curCloth.color);
            CB_color.SelectedItem = _curColor.name;

            foreach (var item in App.db.Composition.ToList()) 
            {
                CB_composition.Items.Add(item.name);
            }
            var _curComposition = App.db.Composition.FirstOrDefault(x => x.Id_composition == _curCloth.composition);
            CB_composition.SelectedItem = _curComposition.name;

            foreach (var item in App.db.Size.ToList())
            {
                CB_size.Items.Add(item.name);
            }
            var _curSize = App.db.Size.FirstOrDefault(x => x.Id_size == _curCloth.size);
            CB_size.SelectedItem = _curSize.name;

            foreach (var item in App.db.Supplier.ToList())
            {
                CB_supplier.Items.Add(item.name);
            }
            var _curSuplier = App.db.Supplier.FirstOrDefault(x => x.Id_supplier == _curCloth.supplier);
            CB_supplier.SelectedItem = _curSuplier.name;

            foreach (var item in App.db.Manufacturer.ToList())
            {
                CB_manufacturer.Items.Add(item.name);
            }
            var _curManufacturer = App.db.Manufacturer.FirstOrDefault(x => x.Id_manufacterer == _curCloth.manufacturer);
            CB_manufacturer.SelectedItem = _curManufacturer.name;

            //Получение даты в DateTimePicker
            TB_delivery_date.Text = _curCloth.delivery_date.ToString();
            TB_purchase_date.Text = _curCloth.purchase_date.ToString();
        }

        private void BT_save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder(); //счётчик ошибок

            if (string.IsNullOrWhiteSpace(_curCloth.name)) //проверка на поле
                errors.AppendLine("Введите название!");

            if (errors.Length > 0) //проверка на ошибки
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_curCloth.Id_cloth == 0) //добавлениеданных в таблицу
                App.db.Cloth.Add(_curCloth);

            try //сохранение
            {
                App.db.SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BT_open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Image | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                img = File.ReadAllBytes(ofd.FileName);
                Image_photo.Source = new ImageSourceConverter().ConvertFrom(img) as ImageSource;
            }
        }

        private void BT_exit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
