using Presentation.Commands;
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

namespace PresentationModel.ViewModels
{
    class AddInventoryViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private Store store;
        private int amount;
        private Product product;

        private ObservableCollection<Product> products;

        public AddInventoryViewModel(Store store)
        {
            this.store = store;
            UpdateInventoryCommand = new UpdateInventoryCommand(this);
            products = store.GetAllProducts();
        }




        public ICommand UpdateInventoryCommand
        {
            get;
            private set;
        }


        public void SaveChanges()
        {
            store.UpdateInventory(Product.Id, Amount);
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


        public Product Product
        {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
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
                if (columnName == "Amount")
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

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("ProductId");
            }
        }
    }
}