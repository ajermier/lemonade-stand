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
        public IceCubes iceCubes;

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
            iceCubes = new IceCubes();
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
        private void UpdateStock()
        {
            lemons.RemoveInventory();
            sugar.RemoveInventory();
            iceCubes.RemoveInventory();
            cups.RemoveInventory();
        }

        protected virtual void RemoveInventory()
        {
            stock = stock - 1;
        }

        public int PromptForBatch()
        {
            int amount;
            Console.Write("Enter number of cups of lemonade you want to prepare for today: ");
            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
            {
                Console.Write("ALERT: Enter a positive number or 0 to not make any: ");
            }

            return amount;
        }
        public void MakeBatch(int amount)
        {
            while (lemons.stock >= lemons.unitProportion && sugar.stock >= sugar.unitProportion && cups.stock >= cups.unitProportion && iceCubes.stock >= iceCubes.unitProportion && supply < amount)
            {
                supply = supply + 1;
                UpdateStock();
            }

            Console.WriteLine($"You had enough ingredients to make {supply} of {amount} cups of lemonade today.");
            Console.WriteLine();
        }
        public void DisplayInventory()
        {
            string lem = string.Format("{0:N1}", Math.Round(lemons.stock * 100) / 100);
            string sug = string.Format("{0:N1}", Math.Round(sugar.stock * 100) / 100);
            Console.WriteLine("-----Inventory-----");
            Console.WriteLine($"Lemons: {lem}");
            Console.WriteLine($"Sugar: {sug} cups");
            Console.WriteLine($"Ice Cubes: {iceCubes.stock}");
            Console.WriteLine($"Cups: {cups.stock}");
            Console.WriteLine();
        }
    }
}
