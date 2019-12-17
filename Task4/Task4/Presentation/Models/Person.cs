using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4;

namespace Presentation.Models
{
    public class Personn : IDataErrorInfo, INotifyPropertyChanged
    {
        private Store store;
        private string firstName;
        private string lastName;
        private int id;

        public Personn(Store store)
        {
            this.store = store;
            firstName = "FirstName";
            lastName = "LastName";
            id = 100;
        }

        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public void CreatePerson()
        {
            store.CreateUser(firstName, lastName, id);
        }



        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyFirstName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyFirstName));
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
