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
using WpfApp1_Lab.Helper;
using WpfApp1_Lab.Model;
using WpfApp1_Lab.ViewModel;

namespace WpfApp1_Lab
{
    /// <summary>
    /// Логика взаимодействия для WindowNewEmployee.xaml
    /// </summary>
    public partial class WindowNewEmployee : Window
    {
        private RoleViewModel roleViewModel;
        public WindowNewEmployee()
        {
            InitializeComponent();
            CbRole.ItemsSource = new RoleViewModel().ListRole;
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
