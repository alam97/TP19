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
    class ViewAllEventsModel
    {
        private Store store;
      
        public ObservableCollection<Event> ewents { get; set; }
        private ObservableCollection<Object> displayGrid;

        public ViewAllEventsModel(Store store)
        {
            this.store = store;
            ewents = store.GetAllEvents();
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
