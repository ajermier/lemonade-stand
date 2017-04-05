using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Cups : Inventory
    {
        //member variables
        public double unitProportion;
        public static double unitPrice;
        public int buyAmount;

        //constructors
        public Cups()
        {
            unitPrice = 0.07;
            unitProportion = 1;
            quantity = 0;
            stock = 0;
        }

        //methods
        public int Buy()
        {
            string price = string.Format("{0:N2}", Math.Round(Cups.unitPrice * 100) / 100);
            Console.WriteLine($"Cups cost ${price} per cup.");
            Console.Write("Enter amount of cups to purchase: ");
            int.TryParse(Console.ReadLine(), out buyAmount);
            Console.WriteLine();
            return buyAmount;
        }
        public double GetUnitCost()
        {
            double unitCost = (unitProportion) * unitPrice;

            return unitCost;
        }
    }
}