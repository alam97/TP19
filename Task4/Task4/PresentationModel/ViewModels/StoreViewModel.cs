using Presentation.Commands;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace Presentation.ViewModels
{
    public class StoreViewModel
    {

        private AddPersonViewModel addUserViewModel;
        public Window user;

        public StoreViewModel(Window user)
        {
            addUserViewModel = new AddPersonViewModel();
            AddPersonCommand = new AddPersonButtonCommand(this);
            this.user = user;
        }
        
 
        public ICommand AddPersonCommand
        {
            get;
            private set;
        }


        public void AddPersonViewCreate(Window view)
        {
           
            view.DataContext = addUserViewModel;
            view.ShowDialog();
        }


    }
}

