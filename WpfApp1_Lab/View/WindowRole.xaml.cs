using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace WpfApp1_Lab.View
{
    /// <summary>
    /// Логика взаимодействия для WindowRole.xaml
    /// </summary>
    public partial class WindowRole : Window
    {   
        RoleViewModel vmRole;

        public WindowRole()
        {
            InitializeComponent();
            vmRole = new RoleViewModel();
            DataContext = vmRole;
        }

        private void RoleListView_Select(object sender, SelectionChangedEventArgs e)
        {
            if (LvRole.SelectedItem != null)
            {
                vmRole.SelectedRole = (Role)LvRole.SelectedItem;
            }
        }
    }
}


