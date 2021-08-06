using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using GroceryStore.View;

namespace GroceryStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateWarehousesList();
        }
        private void Warehouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WarehousesList.SelectedItem is null)
            {
                return;
            }
            Warehouse warehouse = WarehousesList.SelectedItem as Warehouse;
            using (GroceryStoreModelContainer container = new GroceryStoreModelContainer())
            {
                List<Storege> storeges = container.StoregeSet.ToList();
                MainDataGrid.ItemsSource = from stor in storeges
                                           where stor.Warehouse.Id == warehouse.Id
                                           select new
                                           {
                                               Id = stor.Id,
                                               Name = stor.Product.Name,
                                               Price = stor.Product.Price,
                                               Count = stor.Count
                                           };
            }
            if (MainDataGrid.Columns.Count == 0)
            {
                return;
            }
            MainDataGrid.Columns[0].Visibility = Visibility.Collapsed;
        }
        private void UpdateWarehousesList()
        {
            using (GroceryStoreModelContainer container = new GroceryStoreModelContainer())
            {
                WarehousesList.ItemsSource = container.WarehouseSet.ToList();
            }
        }

        private void AddingMenuItem_Click(object sender, RoutedEventArgs e)
        {
            StoreEditionWindow window = new StoreEditionWindow();
            window.Show();
        }

        private void UpdateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Storege storege = GetSelectedStoregeByDataGrid();
            StoreEditionWindow window = new StoreEditionWindow(storege);
            window.Show();
        }
        private Storege GetSelectedStoregeByDataGrid()
        {
            dynamic item = MainDataGrid.SelectedItem;
            int id = item.Id;
            Storege storege;
            using (GroceryStoreModelContainer container = new GroceryStoreModelContainer())
            {
               storege = container.StoregeSet.Find(id);
            }
            return storege;
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            using (GroceryStoreModelContainer container = new GroceryStoreModelContainer())
            {
                Storege storege = container.StoregeSet.Find(GetSelectedStoregeByDataGrid().Id);
                container.StoregeSet.Remove(storege);
                container.SaveChanges();
            }
        }

        private void DataProductMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataWarehouseMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateWarehousesList();
            MainDataGrid.ItemsSource = null;
        }
    }
}
