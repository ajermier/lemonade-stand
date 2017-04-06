using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class IceCubes : Inventory
    {
        //member variables
        public int unitProportion;
        public static double unitPrice;
        public double bulkPrice;
        public int bulkAmount;
        public int buyAmount;

        //constructors
        public IceCubes()
        {
            unitPrice = 0.02;
            bulkAmount = 150;
            bulkPrice = unitPrice * bulkAmount;
            unitProportion = 3;
            quantity = 0;
            stock = 0;
        }

        //methods
        public int Buy()
        {
            string price = string.Format("{0:N2}", Math.Round(bulkPrice * 100) / 100);

            Console.WriteLine($"Ice costs ${price} per 5 lb bag ({bulkAmount} cubes).");
            Console.Write("Enter amount of 5 lb bags of ice to purchase: ");
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
        public override void RemoveInventory()
        {
            stock = stock - (unitProportion);
        }
    }
}
