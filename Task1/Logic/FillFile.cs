using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    class FillFile : DataFill
    {
        public void Fill(DataRepository data)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Users.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.AddUser(new User(words[0], words[1], Int32.Parse(words[3])));

            }
            lines = System.IO.File.ReadAllLines(@"Catalogs.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.AddProduct(new Product(words[0], Double.Parse(words[2]), int.Parse(words[3])));
            }

            lines = System.IO.File.ReadAllLines(@"Inventory.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');

                foreach (Product c in data.GetAllProducts())
                {
                    if (c.ProductID == Int32.Parse(words[0]))
                        data.UpdateInventory(c, int.Parse(words[1]));
                }
            }

            lines = System.IO.File.ReadAllLines(@"Events.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.AddEvent(new Event(data.GetUser(int.Parse(words[1])), data.GetProduct(int.Parse(words[2])), DateTime.Parse(words[3])));
            }
        }
    }
}
