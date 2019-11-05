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
        // status is like a record if a catalog is currently available in the shop
            private Catalog catalog;
            private int amount;
            private DateTimeOffset dateOfinventory;
            private int inventoryId;

            public Inventory(Catalog catalog, int amount, DateTimeOffset dateOfinventory, int inventoryId)
            {
            this.catalog = catalog;
            this.amount = amount;
            this.dateOfinventory = dateOfinventory;
            this.inventoryId = inventoryId;

            }

            public int InventoryID { get => inventoryId; set => inventoryId = value; }
            public Catalog InventoryCatalog { get => catalog; }

        }
}
