using Presentation.Commands;
using Presentation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task4;

namespace Presentation.ViewModels
{
    public class AddPersonViewModel 
    {

        private Personn person;
        private Store store;


      

        public AddPersonViewModel(Store store)
        {
            this.store = store;
            person = new Personn(this.store);
            AddPersonCommand = new AddPersonCommand(this);
        }

        public Personn Person
        {
            get
            {
                return person;
            }
        }

        public ICommand AddPersonCommand
        {
            get;
            private set;
        }

        public void SaveChanges()
        {
            person.CreatePerson();
        }
    }
}
