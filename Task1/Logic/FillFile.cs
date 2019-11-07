using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class FillFile : DataFill
    {
        public FillFile() { }

        public void Fill(DataRepository data)
        {
            string[] lines = System.IO.File.ReadAllLines("../../../Resources/Users.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.AddUser(new User(words[0], words[1], int.Parse(words[2])));

            }
            lines = System.IO.File.ReadAllLines("../../../Resources/Catalogs.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.AddProduct(new Product(words[0], double.Parse(words[1], CultureInfo.InvariantCulture), int.Parse(words[2])));
            }

            lines = System.IO.File.ReadAllLines("../../../Resources/Inventory.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');

                foreach (Product c in data.GetAllProducts())
                {
                    if (c.ProductID == Int32.Parse(words[0]))
                        data.AddProductToInventory(c, int.Parse(words[1]));
                }
            }

            lines = System.IO.File.ReadAllLines("../../../Resources/Events.txt");
            foreach (string line in lines)
            {
                string[] words = line.Split(';');
                data.AddEvent(new Event(data.GetUser(int.Parse(words[0])), data.GetProduct(int.Parse(words[1])), DateTime.Parse(words[2])));
            }
        }
    }
}
