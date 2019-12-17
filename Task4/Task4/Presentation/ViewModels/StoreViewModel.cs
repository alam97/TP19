﻿using Presentation.Commands;
using PresentationModel.Commands;
using PresentationModel.ViewModels;
using Services;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace Presentation.ViewModels
{
    public class StoreViewModel
    {
        private Store store;
        private AddPersonViewModel addUserViewModel;
        private AddInventoryViewModel addInventoryViewModel;
        private AddInvoiceViewModel addInvoiceViewModel;
        private AddProductViewModel addProductViewModel;

        public StoreViewModel(Window user, Window invoice, Window inventory, Window product)
        {
            this.store = new Store();

            addUserViewModel = new AddPersonViewModel(this.store);
            addInventoryViewModel = new AddInventoryViewModel();
            addInvoiceViewModel = new AddInvoiceViewModel(this.store);
            addProductViewModel = new AddProductViewModel(this.store);


            AddPersonCommand = new AddPersonButtonCommand(this);
            AddInventoryCommand = new AddInventoryButtonCommand(this);
            AddInvoiceCommand = new AddInvoiceButtonCommand(this);
            AddProductCommand = new AddProductButtonCommand(this);
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



        public void AddInventoryViewCreate()
        {
            AddInvetoryView view = new AddInvetoryView();
            view.DataContext = addInventoryViewModel;
            view.ShowDialog();
        }

        public void AddInvoiceViewCreate()
        {
            AddInvoiceView view = new AddInvoiceView();
            view.DataContext = addInvoiceViewModel;
            view.ShowDialog();
        }

        public void AddPersonViewCreate()
        {
            AddPersonView view = new AddPersonView();
            view.DataContext = addUserViewModel;
            view.ShowDialog();
        }
        public void AddProductViewCreate()
        {
            AddProductView view = new AddProductView();
            view.DataContext = addProductViewModel;
            view.ShowDialog();
        }


    }
}
