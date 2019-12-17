using Presentation.Commands;
using Presentation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task4;

namespace Presentation.ViewModels
{
    public class AddPersonViewModel : IDataErrorInfo, INotifyPropertyChanged
    {

        private Person person;
        private Store store;
      

        public AddPersonViewModel(Store store)
        {
            this.store = store;
            person = new Person()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Id = 10
            };
            AddPersonCommand = new AddPersonCommand(this);
        }

        public Person Person
        {
            get
            {
                return person;
            }
        }

        public ICommand AddPersonCommand
        {
            get;
            private set;
        }

        public void SaveChanges()
        {
            store.CreateUser(FirstName, LastName, Id);
        }

        public String FirstName
        {
            get
            {
                return person.FirstName;
            }
            set
            {
                person.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public String LastName
        {
            get
            {
                return person.LastName;
            }
            set
            {
                person.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public int Id
        {
            get
            {
                return person.Id;
            }
            set
            {
                person.Id = value;
                OnPropertyChanged("Id");
            }
        }



        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        #region IDataErrorInfo Members

        public string Error
        {
            get;
            private set;
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "FirstName")
                {
                    if (String.IsNullOrWhiteSpace(FirstName))
                    {
                        Error = "FirstName cannot be null or empty.";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                else if (columnName == "LastName")
                {
                    if (String.IsNullOrWhiteSpace(LastName))
                    {
                        Error = "LastName cannot be null or empty.";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                else if (columnName == "Id")
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(Id)))
                    {
                        Error = "Id cannot be null or empty.";
                    }
                    else
                    {
                        Error = null;
                    }
                }


                return Error;
            }
        }

        #endregion
    }
}
