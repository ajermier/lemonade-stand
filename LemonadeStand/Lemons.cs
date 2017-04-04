using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemons : Inventory
    {
        //member variables
        public double unitProportion;

        //constructors
        public Lemons()
        {
            unitPrice = 0.25;
            unitProportion = 1.00;
            quantity = 0;
            stock = 0;
        }

        //methods
        public override void AddNewInventory()
        {
            Console.WriteLine("Enter amount of lemons to purchase: ");
            int.TryParse(Console.ReadLine(), out quantity);
            stock = stock + quantity;
        }

        public override void RemoveInventory()
        {
            double lemonsPerCup = 3;
            stock = stock - (unitProportion/totalServingProportion)*lemonsPerCup;
        }
    }
}

