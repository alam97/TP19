using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    class Invoice : IDataErrorInfo, INotifyPropertyChanged
    {
        private Store store;
        private int productId;
        private int personId;
        private int amount;

        public Invoice(Store store)
        {
            this.store = store;
            productId = 100;
            personId = 100;
            amount = 10;
        }

        public int PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
                OnPropertyChanged("PersonId");
            }
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
                OnPropertyChanged("Id");
            }
        }

        public void CreateInvoice()
        {
            store.BuyItem(personId, productId, Amount);
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
                if (columnName == "PersonId")
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(PersonId)))
                    {
                        Error = "PersonId cannot be null or empty.";
                    }
                    else
                    {
                        Error = null;
                    }
                }
                else if (columnName == "ProductId")
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