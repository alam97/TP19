using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    class Inventory : IDataErrorInfo, INotifyPropertyChanged
    {
        private Store store;
        private int productId;
        private int amount;


        public Inventory(Store store)
        {
            this.store = store;
            productId = 100;
            amount = 100;
        }

        public int ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
                OnPropertyChanged("ProductId");
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        }

        public void CreatePerson()
        {
            store.CreateUser("Aleksander", "Brylski", 20);
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
             if (columnName == "ProductId")
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(ProductId)))
                    {
                        Error = "ProductId cannot be null or empty.";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                else if (columnName == "Amount")
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(Amount)))
                    {
                        Error = "Amount cannot be null or empty.";
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