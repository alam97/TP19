//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Data;

//namespace Logic
//{
//    class FillFile : DataFill
//    {
//        public void Fill(DataContext context)
//        {
//            string[] lines = System.IO.File.ReadAllLines(@"Users.txt");
//            foreach (string line in lines)
//            {
//                string[] words = line.Split(';');
//                context.users.Add(new User(words[0], words[1], Int32.Parse(words[3])));

//            }
//            lines = System.IO.File.ReadAllLines(@"Catalogs.txt");
//            int i = 0;
//            foreach (string line in lines)
//            {
//                string[] words = line.Split(';');
//                context.catalogs.Add(i, new Catalog(words[0], Double.Parse(words[2]), int.Parse(words[3])));
//                i++;
//            }

//            lines = System.IO.File.ReadAllLines(@"Inventory.txt");
//            foreach (string line in lines)
//            {
//                string[] words = line.Split(';');

//                foreach (Catalog c in context.catalogs.Values)
//                {
//                    if (c.ProductID == Int32.Parse(words[0]))
//                        context.inventory.Add(new Inventory(c, int.Parse(words[1]), DateTime.Parse(words[2]), int.Parse(words[3])));
//                }
//            }

//            lines = System.IO.File.ReadAllLines(@"Events.txt");
//            foreach (string line in lines)
//            {
//                string[] words = line.Split(';');
//                context.events.Add(new Event(context.users[int.Parse(words[1])], context.catalogs[int.Parse(words[2])], DateTime.Parse(words[3])));
//            }
//        }
//    }
//}
