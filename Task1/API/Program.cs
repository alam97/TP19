using Data;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            FillConst fillConst = new FillConst();
            Shop shop = new Shop(fillConst);
            shop.CreateUser("Aleksander", "Brylski", 66);
            Product P = new Product("Knife", 14.21, 7);
            shop.CreateProduct("Knife", 14.21, 7);
            shop.AddToInventory(P, 25);
            shop.BuyItem(shop.Data.GetUser(66), shop.Data.GetProduct(7), 5);
        }
    }
}
