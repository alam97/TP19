using Presentation.Commands;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task4;

namespace Presentation.ViewModels
{
    class ViewAllProductsModel
    {
        private Store store;
        public ObservableCollection<Product> products { get; set; }
        private ObservableCollection<Object> displayGrid;

        public ViewAllProductsModel(Store store)
        {
            this.store = store;  
            products = store.GetAllProducts();
        }

        public void SetDisplayCollection(int a)
        {
            if (a == 1)
            {

            }
        }


        public ObservableCollection<Object> Grid
        {
            get
            {

                return displayGrid;
            }
        }
    }
}
