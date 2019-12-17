using Presentation.Commands;
using Presentation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task4;

namespace PresentationModel.ViewModels
{
    class AddProductViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private Product product;
        private Store store;

        public AddProductViewModel(Store store)
        {
            this.store = store;
            product = new Product()
            {
                Name = "Name",
                Price = (decimal)19.99,
                Id = 10
            };
            AddProductCommand = new AddProductCommand(this);
        }

        public Product Product
        {
            get
            {
                return product;
            }
        }

        public ICommand AddProductCommand
        {
            get;
            private set;
        }

        public void SaveChanges()
        {
            store.CreateProduct(Name, Price, Id);
        }


        public String Name
        {
            get
            {
                return product.Name;
            }
            set
            {
                product.Name = value;
                OnPropertyChanged("FirstName");
            }
        }
        public Double Price
        {
            get
            {
                return (double)product.Price;
            }
            set
            {
                product.Price = (decimal)value;
                OnPropertyChanged("Price");
            }
        }
        public int Id
        {
            get
            {
                return product.Id;
            }
            set
            {
                product.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public void CreateProduct()
        {
            store.CreateProduct(Name, Price, Id);
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

   