using PresentationModel.ViewModel;
using PresentationModel.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
           ShowUserManagementWindowCommand = new RelayCommand(() => UserManagementWindow.Value.Show());
            ShowProductManagementCommand = new RelayCommand(() => ProductManagementWindow.Value.Show());
            ShowInvoiceManagementCommand = new RelayCommand(() => InvoiceManagementWindow.Value.Show());
            ShowInventoryManagementCommand = new RelayCommand(() => InventoryManagmentWindow.Value.Show());
        }

        public Lazy<IWindow> UserManagementWindow { get; set; }
        public Lazy<IWindow> ProductManagementWindow { get; set; }
        public Lazy<IWindow> InvoiceManagementWindow { get; set; }
        public Lazy<IWindow> InventoryManagmentWindow { get; set; }

      
        public Lazy<IWindow> ChildWindow { get; set; }

        public ICommand ShowUserManagementWindowCommand
        {
            get; private set;
        }
        private void ShowUserManagementWindow()
        {
            IWindow _child = ChildWindow.Value;
            _child.Show();
        }

        public RelayCommand ShowProductManagementCommand
        {
            get; private set;
        }

        public RelayCommand ShowInvoiceManagementCommand
        {
            get; private set;
        }

        public RelayCommand ShowInventoryManagementCommand
        {
            get; private set;
        }
    }
}
