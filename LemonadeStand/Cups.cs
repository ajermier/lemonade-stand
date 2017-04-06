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
        public double bulkPrice;
        public int bulkAmount;
        public int buyAmount;

        //constructors
        public Cups()
        {
            unitPrice = 0.07;
            bulkAmount = 25;
            bulkPrice = unitPrice * bulkAmount;
            unitProportion = 1;
            quantity = 0;
            stock = 0;
        }

        //methods
        public int Buy()
        {
            string price = string.Format("{0:N2}", Math.Round(bulkPrice * 100) / 100);
            Console.WriteLine($"Cups cost ${price} per {bulkAmount} count pack.");
            Console.Write("Enter amount of cups to purchase: ");
            while (!int.TryParse(Console.ReadLine(), out buyAmount) || buyAmount < 0)
            {
                Console.Write("ALERT: Enter a positive number or 0 to not purchase anything:");
            }
            buyAmount = buyAmount * bulkAmount;

            return buyAmount;
        }
        public double GetUnitCost()
        {
            double unitCost = (unitProportion) * unitPrice;

            return unitCost;
        }
    }
}