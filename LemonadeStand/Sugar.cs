using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Sugar : Inventory
    {
        public Sugar()
        {
            unitPrice = 0.30;
            quantity = AddNewInventory();
        }
        public override int AddNewInventory()
        {
            Console.WriteLine("Enter amount of sugar (in cups) to purchase: ");
            int.TryParse(Console.ReadLine(), out quantity);
            return quantity;
        }
    }
}
