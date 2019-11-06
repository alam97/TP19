using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext
    {
        public List<User> users = new List<User>();
        // stores definitions of the products
        public List<Product> catalog = new List<Product>();
        // stores how many products there are in the shop currently
        public Dictionary<Product, int> inventory = new Dictionary<Product, int>();
        public ObservableCollection<Event> events = new ObservableCollection<Event>();
    }
}
