﻿using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfApp1_Lab.Helper;
using WpfApp1_Lab.Model;

namespace WpfApp1_Lab.ViewModel
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        private PersonDPO _selectedPersonDpo;

        public PersonDPO SelectedPersonDpo
        {
            get { return _selectedPersonDpo; }
            set
            {
                _selectedPersonDpo = value;
                OnPropertyChanged("SelectedPersonDpo");
            }
        }

        public ObservableCollection<Person> ListPerson { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<PersonDPO> ListPersonDpo { get; set; } = new ObservableCollection<PersonDPO>();


        public PersonViewModel()
        {
            this.ListPerson.Add(
                new Person
                {
                    Id = 1,
                    RoleId = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Birthday = new DateTime(1980, 02, 28)
                });
            this.ListPerson.Add(
                new Person
                {
                    Id = 2,
                    RoleId = 2,
                    FirstName = "Петр",
                    LastName = "Петров",
                    Birthday = new DateTime(1981, 03, 20)
                });
            this.ListPerson.Add(
                new Person
                {
                    Id = 3,
                    RoleId = 3,
                    FirstName = "Виктор",
                    LastName = "Викторов",
                    Birthday = new DateTime(1982, 04, 15)
                });
            this.ListPerson.Add(
                new Person
                {
                    Id = 4,
                    RoleId = 3,
                    FirstName = "Сидор",
                    LastName = "Сидоров",
                    Birthday = new DateTime(1983, 05, 10)
                });
            ListPersonDpo = GetListPersonDpo();
        }

        public ObservableCollection<PersonDPO> GetListPersonDpo()
        {
            foreach (var person in ListPerson)
            {
                PersonDPO p = new PersonDPO();
                p = p.CopyFromPerson(person);
                ListPersonDpo.Add(p);
            }
            return ListPersonDpo;
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListPerson)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }

        #region AddPerson


        private RelayCommand addPerson;
        /// <summary>
        /// добавление сотрудника
        /// </summary>
        public RelayCommand AddPerson
        {
            get
            {
                return addPerson ??
                (addPerson = new RelayCommand(obj =>
                {
                    WindowNewEmployee wnPerson = new WindowNewEmployee
                    {
                        Title = "Новый сотрудник"
                    };
                    // формирование кода нового сотрудника
                    int maxIdPerson = MaxId() + 1;
                    PersonDPO per = new PersonDPO
                    {
                        Id = maxIdPerson,
                        Birthday = DateTime.Now
                    };
                    wnPerson.DataContext = per;
                    if (wnPerson.ShowDialog() == true)
                    {
                        RoleViewModel roleViewModel = new RoleViewModel();
                        per.RoleName = roleViewModel.ListRole.FirstOrDefault()?.NameRole;
                        ListPersonDpo.Add(per);
                        // добавление нового сотрудника в коллекцию ListPerson<Person> 
                        Person p = new Person();
                        p = p.CopyFromPersonDPO(per);
                        ListPerson.Add(p);
                    }
                },
                (obj) => true));
            }
        }


        #endregion

        #region EditPerson

        private RelayCommand editPerson;
        public RelayCommand EditPerson
        {
            get
            {
                return editPerson ??
                (editPerson = new RelayCommand(obj =>
                {
                    WindowNewEmployee wnPerson = new WindowNewEmployee()
                    {
                        Title = "Редактирование данных сотрудника",
                    };
                    PersonDPO personDpo = SelectedPersonDpo;
                    PersonDPO tempPerson = new PersonDPO();
                    tempPerson = personDpo.ShallowCopy();
                    wnPerson.DataContext = tempPerson;

                    if (wnPerson.ShowDialog() == true)
                    {
                        // сохранение данных в оперативной памяти
                        personDpo.RoleName = tempPerson.RoleName;
                        personDpo.FirstName = tempPerson.FirstName;
                        personDpo.LastName = tempPerson.LastName;
                        personDpo.Birthday = tempPerson.Birthday;

                        // перенос данных из класса отображения данных в класс Person
                        Person p = ListPerson.FirstOrDefault(person => person.Id == personDpo.Id);
                        if (p != null)
                        {
                            p = p.CopyFromPersonDPO(personDpo);
                        }
                    }
                },
                (obj) => SelectedPersonDpo != null && ListPersonDpo.Count > 0));
            }
        }


        #endregion

        #region DeletePerson

        private RelayCommand deletePerson;
        public RelayCommand DeletePerson
        {
            get
            {
                return deletePerson ??
                (deletePerson = new RelayCommand(obj =>
                {
                    PersonDPO person = SelectedPersonDpo;
                    MessageBoxResult result = MessageBox.Show("Удалить  данные по сотруднику: \n" + person.LastName + " " + person.FirstName, "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK)
                    {
                        // удаление данных в списке отображения данных
                        ListPersonDpo.Remove(person);
                        // удаление данных в списке классов ListPerson<Person>
                        Person per = new Person();
                        per = per.CopyFromPersonDPO(person);
                        ListPerson.Remove(per);
                    }
                }, (obj) => SelectedPersonDpo != null && ListPersonDpo.Count > 0));
            }
        }


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]
string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
