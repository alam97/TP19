using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataRepository
    {
        private DataContext context;

        public DataRepository(DataContext c)
        {
            this.context = c;
        }


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
    }
}
