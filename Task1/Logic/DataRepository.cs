using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class DataRepository
    {
        private DataContext context;
        private DataFill fill;

        public DataRepository(DataContext context, DataFill fill)
        {
            this.context = context;
            this.fill = fill;
        }

        public void FillStatic() => fill.Fill(context);

        #region User
        public void AddUser(User u)
        {
            if (context.users.Exists(x => x.UserID == u.UserID))
            {
                throw new Exception("Such an user already exists");
            }
            context.users.Add(u);
        }

        public User GetUser(int id)
        {
            if (context.users.Exists(x=>x.UserID == id))
            {
                return context.users[id];
            }
            throw new Exception("No such an user");
        }

        public IEnumerable<User> GetAllUsers()
        {
            return context.users;
        }

        public void DeleteUser(int id)
        {
            User tmp = GetUser(id);
            context.users.Remove(tmp);
        }
        #endregion

        #region Event
        public void AddEvent(Event e)
        {
            context.events.Add(e);
        }

        public Event GetEvent(int id)
        {
            return context.events[id];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return context.events;
        }

        public void DeleteEvent(int id)
        {
            
        }
        #endregion

        #region Inventory
        
        public void AddInventory(Inventory i)
        {
            if (context.inventory.Exists(x => x.InventoryID == i.InventoryID))
            {
                throw new Exception("Such an inventory already exists");
            }
            context.inventory.Add(i);
        }
        public Inventory GetInventory(int id)
        {
            if (context.inventory.Exists(x => x.InventoryID == id))
            {
                return context.inventory[id];
            }
            throw new Exception("No such an inventory");
        }

        public IEnumerable<Inventory> GetAllInventories()
        {
            return context.inventory;
        }

        public void DeleteInventory(int id)
        {
            Inventory tmp = GetInventory(id);
            context.inventory.Remove(tmp);
        }

        #endregion

        #region Catalog
        // catalogs are stored in a dictionary, a collection
        // with fast access thanks to the TKey and TValue pairs
        // TKey is created in DataRepository, it cannot be 
        // catalog's id because id is explicit to type of the product sold
        // and not an "instance" of the product stored 
        private int catalogKey = 0;
        public int Catalogkey { get => catalogKey; set => catalogKey = value; }

        public void AddCatalog(Catalog c)
        {
            context.catalogs.Add(catalogKey, c);
            catalogKey++;
        }
        public Catalog GetCatalog(int key)
        {
            return context.catalogs[key];
        }
        public IEnumerable<Catalog> GetAllCatalogs()
        {
            return context.catalogs.Values;
        }
        public void DeleteCatalog(int key)
        {
           if ( context.inventory.Exists(x=> x.InventoryCatalog == context.catalogs[key]))
            {
                throw new Exception("Catalog cannot be deleted, it exists in the inventory");
            }
            context.catalogs.Remove(key);
        }

        #endregion
    }
}
