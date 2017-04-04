using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Sugar : Inventory
    {
        //member variables
        public double unitProportion;

        //constructors
        public Sugar()
        {
            unitPrice = 0.30;
            unitProportion = 0.50;
            quantity = 0;
            stock = 0;
        }

        //methods
        public override void AddNewInventory()
        {
            Console.WriteLine("Enter amount of sugar (in cups) to purchase: ");
            int.TryParse(Console.ReadLine(), out quantity);
            stock = stock + quantity;
        }

        public override void RemoveInventory()
        {
            stock = stock - (unitProportion / totalServingProportion);
        }
    }
}
