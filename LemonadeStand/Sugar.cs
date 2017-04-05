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
            string price = string.Format("{0:N2}", Math.Round(Sugar.unitPrice * 100) / 100);
            Console.WriteLine($"Sugar costs ${price} per cup.");
            Console.Write("Enter amount of sugar (in cups) to purchase: ");
            int.TryParse(Console.ReadLine(), out quantity);
            stock = stock + quantity;
            Console.WriteLine();
        }

        public override void RemoveInventory()
        {
            stock = stock - (unitProportion / totalServingProportion);
            if (stock < unitProportion / totalServingProportion) stock = 0;
        }
        public double GetUnitCost()
        {
            double unitCost = (unitProportion/totalServingProportion) * unitPrice;

            return unitCost;
        }
    }
}
