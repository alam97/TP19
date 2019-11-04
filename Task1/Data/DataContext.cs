﻿using System;
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
        public Dictionary<int, Catalog> catalogs = new Dictionary<int, Catalog>();
        public System.Collections.ObjectModel.ObservableCollection<Event> events = new ObservableCollection<Event>();
        public List<Inventory> inventory = new List<Inventory>();
    }
}
