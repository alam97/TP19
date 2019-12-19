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
    class ViewAllViewModel
    {
        private Store store;
        public ObservableCollection<Person> persons { get; set; }

        private ObservableCollection<Object> displayGrid;

        public ViewAllViewModel(Store store)
        {
            this.store = store;
            persons = store.GetAllPersons();
        }

        public void SetDisplayCollection(int a)
        {
            if( a == 1)
            {
              
            }
        }


        public ObservableCollection<Object> Grid
        {
            get {

                return displayGrid;
            }
        }
    }
}
