using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemons : Inventory
    {
        public Lemons()
        {
            unitPrice = 0.25;
            quantity = 0;
        }

        public override int AddNewInventory()
        {
            Console.WriteLine("Enter amount of lemons to purchase: ");
            int.TryParse(Console.ReadLine(), out quantity);
            return quantity;
        }
    }
}

