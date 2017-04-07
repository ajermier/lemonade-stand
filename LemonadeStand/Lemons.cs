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
        public static double unitPrice;
        public int buyAmount;

        //constructors
        public Lemons()
        {
            unitPrice = 0.25;
            unitProportion = 1.00;
            quantity = 0;
            stock = 0;
        }

        //methods
        public int Buy()
        {
            string price = string.Format("{0:N2}", Math.Round(Lemons.unitPrice * 100) / 100);
            Console.WriteLine($"Lemons cost ${price} per lemon.");
            Console.Write("Enter amount of lemons to purchase: ");
            while (!int.TryParse(Console.ReadLine(), out buyAmount) || buyAmount < 0)
            {
                Console.Write("ALERT: Enter a positive number or 0 to not purchase anything: ");
            }
            Console.WriteLine();

            return buyAmount;
        }

        protected override void RemoveInventory()
        {
            stock = stock - unitProportion;
        }

        public double GetUnitCost()
        {
            double unitCost = unitProportion * unitPrice;

            return unitCost;
        }
    }
}

