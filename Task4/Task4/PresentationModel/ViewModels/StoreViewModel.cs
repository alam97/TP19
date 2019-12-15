using Presentation.Commands;
using PresentationModel.Commands;
using PresentationModel.ViewModels;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace Presentation.ViewModels
{
    public class StoreViewModel
    {

        private AddPersonViewModel addUserViewModel;
        private AddInventoryViewModel addInventoryViewModel;
        private AddInvoiceViewModel addInvoiceViewModel;
        private AddProductViewModel addProductViewModel;
        public Window user;
        public Window invoice;
        public Window product;
        public Window inventory;

        public StoreViewModel(Window user, Window invoice, Window inventory, Window product)
        {
            addUserViewModel = new AddPersonViewModel();
            addInventoryViewModel = new AddInventoryViewModel();
            addInvoiceViewModel = new AddInvoiceViewModel();
            addProductViewModel = new AddProductViewModel();
            AddPersonCommand = new AddPersonButtonCommand(this);
            AddInventoryCommand = new AddInventoryButtonCommand(this);
            AddInvoiceCommand = new AddInvoiceButtonCommand(this);
            AddProductCommand = new AddProductButtonCommand(this);
            this.user = user;
            this.invoice = invoice;
            this.inventory = inventory;
            this.product = product;
        }
        
 
        public ICommand AddPersonCommand
        {
            get;
            private set;
        }


        public ICommand AddInventoryCommand
        {
            get;
            private set;
        }

        public ICommand AddInvoiceCommand
        {
            get;
            private set;
        }

        public ICommand AddProductCommand
        {
            get;
            private set;
        }



        public void AddInventoryViewCreate(Window view)
        {
           
            view.DataContext = addInventoryViewModel;
            view.ShowDialog();
        }

        public void AddInvoiceViewCreate(Window view)
        {

            view.DataContext = addInvoiceViewModel;
            view.ShowDialog();
        }

        public void AddPersonViewCreate(Window view)
        {

            view.DataContext = addUserViewModel;
            view.ShowDialog();
        }
        public void AddProductViewCreate(Window view)
        {

            view.DataContext = addProductViewModel;
            view.ShowDialog();
        }


    }
}

