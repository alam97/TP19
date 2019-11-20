using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Test
{
    public class FillConst : DataFill
    {
        public FillConst() { }      

        public void Fill(DataRepository data)
        {
            #region users
            //USERS
            data.AddUser(new User("Jan", "Kowalski", 1));
            data.AddUser(new User("Michal", "Smutny", 2));
            data.AddUser(new User("Piotr", "Wesoly", 3));
            data.AddUser(new User("Lukasz", "Ciekawy", 4));
            data.AddUser(new User("Joanna", "Wysoka", 5));
            data.AddUser(new User("Barbara", "Kowalska", 6));
            data.AddUser(new User("Katarzyna", "Szybka", 7));
            #endregion

            #region catalogs
            //CATALOGS
            data.AddProduct(new Product("Sword", 21.21, 1));
            data.AddProduct(new Product("Spear", 23.99, 2));
            data.AddProduct(new Product("Armour", 87.31, 3));
            data.AddProduct(new Product("Axe", 45.11, 4));
            data.AddProduct(new Product("Bow", 19.99, 5));
            data.AddProduct(new Product("Arrow", 1.16, 6));
            #endregion

            #region inventory
            //INVENTORY
            for (int i = 1; i < 7; i++)
            {
                Random amount = new Random();
                data.AddProductToInventory(data.GetProduct(i), i+9);
            }
            #endregion

            #region events
            //EVENTS
            for (int i = 1; i < 6; i++)
            {
                data.AddEvent(new Event(data.GetUser(i), data.GetProduct(i), DateTime.Today));
            }
            #endregion

            //RELATIONS ONE TO MANY (USER BUYS SEVERAL PRODUCTS ON ONE INVOICE)
            data.AddEvent(new Event(data.GetUser(6), data.GetProduct(1), DateTime.Today));
            data.AddEvent(new Event(data.GetUser(6), data.GetProduct(2), DateTime.Today));
            data.AddEvent(new Event(data.GetUser(6), data.GetProduct(3), DateTime.Today));
            data.AddEvent(new Event(data.GetUser(6), data.GetProduct(4), DateTime.Today));
            //07.11.2019 00:00:00


        }
    }
}
