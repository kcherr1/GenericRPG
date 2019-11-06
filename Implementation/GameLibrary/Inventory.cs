using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Inventory
    {
        private int inventoryCount;

        public Inventory()
        {
            this.inventoryCount = 0;
        }

        public void getPotion()
        {
            inventoryCount++;
        }
    }
}
