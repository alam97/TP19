using Presentation.Commands;
using Presentation.Models;
using Services;
using System.Windows.Input;

namespace PresentationModel.ViewModels
{
    class AddInvoiceViewModel
    {
        private Invoice invoice;
        private Store store;

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        public AddInvoiceViewModel(Store store)
        {
            this.store = store;
            invoice = new Invoice(this.store);
            AddInvoiceCommand = new AddInvoiceCommand(this);

        }

    

        /// <summary>
        /// Gets the customer instance
        /// </summary>
        public Invoice Invoice
        {
            get
            {
                return invoice;
            }
        }

        /// <summary>
        /// Gets the UpdateCommand for the ViewModel
        /// </summary>
        public ICommand AddInvoiceCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Saves changes made to the Customer instance
        /// </summary>
        public void SaveChanges()
        {
            invoice.CreateInvoice();
        }
    }
}