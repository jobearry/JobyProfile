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
using raszventory.Model;
using raszventory.Utility;

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

        private void tbSearchDisplay_GotFocus(object sender, RoutedEventArgs e)
        {
            string defaultSearchVal = "Search item (ex. type / name)";
            if (tbSearchDisplay.Text == defaultSearchVal)
            {
                tbSearchDisplay.Text = "";
                tbSearchDisplay.Foreground = Brushes.Black;
            }
        }
    }
}
