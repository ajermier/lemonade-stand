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
        public static double unitPrice;
        public int buyAmount;
        private double bulkPrice;
        private int bulkAmount;

        //constructors
        public Sugar()
        {
            unitPrice = 0.30;
            bulkAmount = 9;
            bulkPrice = unitPrice * bulkAmount;
            unitProportion = 0.50;
            quantity = 0;
            stock = 0;
        }

        //methods
        public int Buy()
        {
            string price = string.Format("{0:N2}", Math.Round(bulkPrice * 100) / 100);
            Console.WriteLine($"Sugar costs ${price} per 4 lb bag ({bulkAmount} cups).");
            Console.Write("Enter amount of 4 lb bags of sugar to purchase: ");
            while(!int.TryParse(Console.ReadLine(), out buyAmount) || buyAmount < 0)
            {
                Console.Write("ALERT: Enter a positive number or 0 to not purchase anything: ");
            }
            buyAmount = buyAmount * bulkAmount;
            Console.WriteLine();

            return buyAmount;
        }

        protected override void RemoveInventory()
        {
            stock = stock - (unitProportion/totalServingProportion);
        }
        public double GetUnitCost()
        {
            double unitCost = (unitProportion/totalServingProportion) * unitPrice;

            return unitCost;
        }
    }
}
