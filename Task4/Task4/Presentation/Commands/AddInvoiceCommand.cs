using PresentationModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.Commands
{
    class AddInvoiceCommand : ICommand
    {
        private AddInvoiceViewModel viewModel;


        public AddInvoiceCommand(AddInvoiceViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event System.EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return String.IsNullOrWhiteSpace(viewModel.Error);
        }

        public void Execute(object parameter)
        {
            viewModel.SaveChanges();
        }
    }
}