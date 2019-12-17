using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    class Product : IDataErrorInfo, INotifyPropertyChanged
    {
        private Store store;
        private string name;
        private double price;
        private int id;

        public Product(Store store)
        {
            this.store = store;
            name = "Name";
            price = 19.99;
            id = 100;
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("FirstName");
            }
        }
        public Double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
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

        public void CreateProduct()
        {
            store.CreateProduct(name, price, id);
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
                if (columnName == "Name" || columnName == "19.99" || columnName == "Id")
                {
                    if (String.IsNullOrWhiteSpace(Name) || String.IsNullOrWhiteSpace(Convert.ToString(Price)) || String.IsNullOrWhiteSpace(Convert.ToString(Id)))
                    {
                        Error = "Box cannot be null or empty.";
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
