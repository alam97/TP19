using PresentationModel.ViewModel.MVVMLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    class InvoiceManagementModel : ViewModelBase
    {
        public InvoiceManagementModel()
        {

        }

        public RelayCommand ShowInvoiceManagementCommand { get; }
    }
}
