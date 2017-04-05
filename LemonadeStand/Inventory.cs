using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        //member variables
        public int quantity;
        public double stock;
        public double totalServingProportion;
        public int supply;
        public Lemons lemons;
        public Sugar sugar;
        public Cups cups;

        //constructors
        public Inventory()
        {
            totalServingProportion = 3;
        }

        //methods
        public virtual void AddNewInventory(int quantity)
        {
            stock = stock + quantity;
        }
        public void AddInitialInventory()
        {
            lemons = new Lemons();
            sugar = new Sugar();
            cups = new Cups();
        }
        public bool CheckSupply()
        {
            if (supply > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("ALERT: You sold out of lemonade before the end of the day. Next time make more lemonade or raise your price!");
                Console.WriteLine();
                return false;
            }
        }
        public void UpdateStock()
        {
            lemons.RemoveInventory();
            sugar.RemoveInventory();
            cups.RemoveInventory();
        }

        public virtual void RemoveInventory()
        {
            stock = stock - 1;
        }
        public void MakeBatch()
        {
            while (lemons.stock >= lemons.unitProportion && sugar.stock >= sugar.unitProportion && cups.stock >= cups.unitProportion )
            {
                supply = supply + 1;
                UpdateStock();
            }

            Console.WriteLine($"You have made enough to sell {supply} glasses of lemonade.");
            Console.WriteLine();
        }
        public void DisplayInventory()
        {
            string lem = string.Format("{0:N1}", Math.Round(lemons.stock * 100) / 100);
            string sug = string.Format("{0:N1}", Math.Round(sugar.stock * 100) / 100);
            Console.WriteLine("-----Inventory-----");
            Console.WriteLine($"Lemons: {lem}");
            Console.WriteLine($"Sugar: {sug} cups");
            Console.WriteLine($"Cups: {cups.stock}");
            Console.WriteLine();
        }
    }
}
