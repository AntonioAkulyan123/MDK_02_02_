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
        }

        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект сотрудника с данными из текстовых полей и комбо-бокса
            PersonDPO newEmployee = new PersonDPO
            {
                Id = int.Parse(TbId.Text),
                Role = CbRole.SelectedItem.ToString(),
                FirstName = TbFirstName.Text,
                LastName = TbLastName.Text,
                Birthday = ClBirthday.SelectedDate.GetValueOrDefault()
            };

            // Добавляем нового сотрудника в коллекцию или передаем его обратно в основное окно для сохранения
            DialogResult = true; // Устанавливаем результат окна как "true", чтобы указать, что сотрудник успешно добавлен
            Close(); // Закрываем окно
        }
    }
}
