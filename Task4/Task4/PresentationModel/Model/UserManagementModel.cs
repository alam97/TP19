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
    class UserManagementModel : ViewModelBase
    {
        public UserManagementModel()
        {
         //   ShowUserManagementCommand = new RelayCommand(AddRoot, () => !string.IsNullOrEmpty(PathVariable));
           
        }

        public RelayCommand ShowUserManagementCommand { get; }
    }
}
