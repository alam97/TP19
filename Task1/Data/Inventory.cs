using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Inventory
    {
        // current status of the shop
            private Catalog catalog;
            private int amount;
            private DateTimeOffset dateOfPurchase;
            private int inventoryId;

            public Inventory()
            {
            }

            public int InventoryID { get => inventoryId; set => inventoryId = value; }

        }
}
