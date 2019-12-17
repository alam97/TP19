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

namespace PresentationModel.ViewModels
{
    class AddProductViewModel
    {
        private Product product;
        private Store store;

        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class.
        /// </summary>
        public AddProductViewModel(Store store)
        {
            this.store = store;
            product = new Product(this.store);
            AddProductCommand = new AddProductCommand(this);
        }

        /// <summary>
        /// Gets the customer instance
        /// </summary>
        public Product Product
        {
            get
            {
                return product;
            }
        }

        /// <summary>
        /// Gets the UpdateCommand for the ViewModel
        /// </summary>
        public ICommand AddProductCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Saves changes made to the Customer instance
        /// </summary>
        public void SaveChanges()
        {
            product.CreateProduct();
        }
    }
}

    