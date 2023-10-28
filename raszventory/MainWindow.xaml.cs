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
            DataSet dSet = sqlService.get(tbSearchDisplay.Text);
            DataTable TableDisplay = new DataTable();
            TableDisplay = dSet.Tables["RZINVT01"]!;
            dgDisplay.SetBinding(ItemsControl.ItemsSourceProperty,
                new Binding
                {
                    Source = dSet.Tables["RZINVT01"],
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                });
        }

    }
}
