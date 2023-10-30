using System;
using System.Collections.Generic;
using System.Data;
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
using raszventory.Model;

namespace raszventory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public List<InventoryModel> InventoryData = new List<InventoryModel>();

        private void SearchDisplayOnFocus(object sender, RoutedEventArgs e)
        {
            string defaultSearchVal = "Search item (ex. type / name)";
            if (tbSearchDisplay.Text == defaultSearchVal)
            {
                tbSearchDisplay.Text = "";
                tbSearchDisplay.Foreground = Brushes.Black;
            }
        }

        private void SearchOnClick(object sender, RoutedEventArgs e)
        {
            SQLService sqlService = new SQLService();
            DataSet dSet = sqlService.Get(tbSearchDisplay.Text);
            InitializeDisplay(dSet);
        }

        private void SaveOnClick(object sender, RoutedEventArgs e)
        {
            SQLService sqlService = new SQLService();
            AddDataToList();
            DataSet dSet = sqlService.Put(InventoryData,tbSearchDisplay.Text);
            InventoryData.Clear();
            InitializeDisplay(dSet);
        }

        public void InitializeDisplay(DataSet data)
        {
            DataTable TableDisplay = new DataTable();
            TableDisplay = data.Tables["RZINVT01"]!;
            dgDisplay.SetBinding(ItemsControl.ItemsSourceProperty,
                new Binding
                {
                    Source = data.Tables["RZINVT01"],
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                });

        }

        public void AddDataToList()
        {
            foreach (DataRowView item in dgDisplay.Items)
            {
                InventoryModel itemContent = new InventoryModel()
                {
                    id = (int)item["id"],
                    item_type = $"{item["item_type"]}".Trim(),
                    item_name = $"{item["item_name"]}".Trim(),
                    item_code = $"{item["item_code"]}".Trim(),
                    model_no = $"{item["model_no"]}".Trim()
                };
                InventoryData.Add(itemContent);
            }
        }
    }
}
