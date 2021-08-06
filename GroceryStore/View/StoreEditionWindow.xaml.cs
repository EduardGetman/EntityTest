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

namespace GroceryStore.View
{
    /// <summary>
    /// Логика взаимодействия для StoreEditionWindow.xaml
    /// </summary>
    public partial class StoreEditionWindow : Window
    {
        Storege Storege { get; set; }
        public StoreEditionWindow()
        {
            InitializeComponent();
            using (GroceryStoreModelContainer container = new GroceryStoreModelContainer())
            {
                ProductComboBox.ItemsSource = container.ProductSet.ToList();
                WarehouseComboBox.ItemsSource = container.WarehouseSet.ToList();
            }
        }
        public StoreEditionWindow(Storege storege)
        {
            InitializeComponent();
            using (GroceryStoreModelContainer container = new GroceryStoreModelContainer())
            {
                ProductComboBox.ItemsSource = container.ProductSet.ToList();
                WarehouseComboBox.ItemsSource = container.WarehouseSet.ToList();
                ProductComboBox.SelectedIndex = 0;
                WarehouseComboBox.SelectedIndex = 0;
            }
            CountTextBox.Text = storege.Count.ToString();
            Storege = storege;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (GroceryStoreModelContainer container = new GroceryStoreModelContainer())
                {
                    if (Storege is null)
                    {
                        Storege = CreateStoregeByFields();
                        container.StoregeSet.Add(Storege);
                        container.Entry(Storege.Product).State = System.Data.Entity.EntityState.Modified;
                        container.Entry(Storege.Warehouse).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        UpdateStoregeByFields();
                        container.StoregeSet.Attach(Storege);
                        container.Entry(Storege).State = System.Data.Entity.EntityState.Modified;
                        container.Entry(Storege.Product).State = System.Data.Entity.EntityState.Modified;
                        container.Entry(Storege.Warehouse).State = System.Data.Entity.EntityState.Modified;
                    }
                    container.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            Close();
        }

        private void UpdateStoregeByFields()
        {
            Storege storege = CreateStoregeByFields();
            Storege.Count = storege.Count;
            Storege.Product = storege.Product;
            Storege.Warehouse = storege.Warehouse;
        }

        private Storege CreateStoregeByFields()
        {
            int count;
            if (!int.TryParse(CountTextBox.Text, out count))
            {                
                throw new Exception("Значение " + CountTextBox.Text + " не является числом!");
            }
            Product product = ProductComboBox.SelectedItem as Product;
            if (product is null)
            {
                throw new Exception("Выберите товар!");
            }
            Warehouse warehouse = WarehouseComboBox.SelectedItem as Warehouse;
            if (warehouse is null)
            {
                throw new Exception("Выберите склад!");
            }
            return new Storege() { Count = count, Product = product, Warehouse = warehouse };

        }
    }
}
