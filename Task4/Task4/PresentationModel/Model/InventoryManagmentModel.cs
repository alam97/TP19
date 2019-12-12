using PresentationModel.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    class InventoryManagmentModel : ViewModelBase
    {
        public InventoryManagmentModel()
        {

        }

        public RelayCommand ShowInventoryManagementCommand { get; }
    }
}
