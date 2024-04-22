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

        public WindowNewEmployee()
        {
            InitializeComponent();
            DataContext = new PersonDPO();

            //Установим контекст данных для ComboBox CbRole
            RoleViewModel roleViewModel = new RoleViewModel();
            CbRole.ItemsSource = roleViewModel.ListRole;
            CbRole.DataContext = roleViewModel;
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект сотрудника с данными из текстовых полей и комбо-бокса
            PersonDPO newEmployee = new PersonDPO
            {
                Id = int.Parse(TbId.Text),
                RoleName = (CbRole.SelectedItem as Role)?.NameRole,
                SelectedRole = CbRole.SelectedItem as Role, // Устанавливаем выбранную должность
                FirstName = TbFirstName.Text,
                LastName = TbLastName.Text,
                Birthday = ClBirthday.SelectedDate.GetValueOrDefault()
            };

            DialogResult = true; // Устанавливаем результат окна как "true", чтобы указать, что сотрудник успешно добавлен
            Close(); // Закрываем окно
        }


    }
}
