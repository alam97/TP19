using Presentation.Commands;
using Presentation.Models;
using Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Task4;

namespace PresentationModel.ViewModels
{ 
    class AddInvoiceViewModel :  INotifyPropertyChanged
    {
        private Store store;
        private int amount;

        private ObservableCollection<Person> persons;
        private ObservableCollection<Product> products;

        public AddInvoiceViewModel(Store store)
        {
            this.store = store;
            AddInvoiceCommand = new AddInvoiceCommand(this);
            persons = store.GetAllPersons();
            products = store.GetAllProducts();
        }




        public ICommand AddInvoiceCommand
        {
            get;
            private set;
        }


        public void SaveChanges()
        {
           // store.BuyItem(PersonId, ProductId, Amount);
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
        //    store.BuyItem(Persons., ProductId, Amount);
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

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        if (columnName == "PersonId")
        //        {
        //            if (String.IsNullOrWhiteSpace(Convert.ToString(PersonId)))
        //            {
        //                Error = "PersonId cannot be null or empty.";
        //            }
        //            else
        //            {
        //                Error = null;
        //            }
        //        }
        //        else if (columnName == "ProductId")
        //        {
        //            if (String.IsNullOrWhiteSpace(Convert.ToString(ProductId)))
        //            {
        //                Error = "ProductId cannot be null or empty.";
        //            }
        //            else
        //            {
        //                Error = null;
        //            }
        //        }
        //        else if (columnName == "Amount")
        //        {
        //            if (String.IsNullOrWhiteSpace(Convert.ToString(Amount)))
        //            {
        //                Error = "Amount cannot be null or empty.";
        //            }
        //            else
        //            {
        //                Error = null;
        //            }
        //        }


        //        return Error;
        //    }
        //}

        #endregion

        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set { persons = value;
                OnPropertyChanged("PersonId");
            }
        }
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set {
                products = value;
                OnPropertyChanged("ProductId");
            }
        }
    }
}