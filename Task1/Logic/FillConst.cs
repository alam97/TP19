using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class FillConst : DataFill
    {
        public FillConst() { }

        public void Fill(DataContext context)
        {
            #region users
            //USERS
            context.users.Add(new User("Jan", "Kowalski", 1));
            context.users.Add(new User("Michał", "Smutny", 2));
            context.users.Add(new User("Piotr", "Wesoły", 3));
            context.users.Add(new User("Łukasz", "Ciekawy", 4));
            context.users.Add(new User("Joanna", "Wysoka", 5));
            context.users.Add(new User("Barbara", "Kowalska", 6));
            context.users.Add(new User("Katarzyna", "Szybka", 7));
            #endregion

            #region catalogs
            //CATALOGS
            context.catalogs.Add(0, new Catalog("Sword", 21.21, 1));
            context.catalogs.Add(0, new Catalog("Sword", 21.21, 1));
            context.catalogs.Add(0, new Catalog("Sword", 21.21, 1));
            context.catalogs.Add(0, new Catalog("Sword", 21.21, 1));
            context.catalogs.Add(0, new Catalog("Sword", 21.21, 1));
            context.catalogs.Add(0, new Catalog("Sword", 21.21, 1));
            context.catalogs.Add(0, new Catalog("Sword", 21.21, 1));
            #endregion

            #region inventory
            //INVENTORY
            for (int i = 0; i < 5; i++)
            {
                Random amount = new Random();
                context.inventory.Add(new Inventory(context.catalogs[i], amount.Next(1, 10), DateTime.Today, i));
            }
            #endregion

            #region events
            //EVENTS
            for (int i = 0; i < 5; i++)
            {
                context.events.Add(new Event(context.users[i], context.catalogs[i], DateTime.Today));
            }
            #endregion

            //RELATIONS ONE TO MANY (USER BUYS SEVERAL PRODUCTS ON ONE INVOICE)
            context.events.Add(new Event(context.users[6], context.catalogs[1], DateTime.Today));
            context.events.Add(new Event(context.users[6], context.catalogs[2], DateTime.Today));
            context.events.Add(new Event(context.users[6], context.catalogs[3], DateTime.Today));
            context.events.Add(new Event(context.users[6], context.catalogs[4], DateTime.Today));

        }
    }
}
