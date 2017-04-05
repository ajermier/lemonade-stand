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

        //constructors
        public Inventory()
        {
            totalServingProportion = 3;
        }

        //methods
        public virtual void AddNewInventory()
        {
            Console.WriteLine("Enter amount to add: ");
            int.TryParse(Console.ReadLine(), out quantity);
            stock = stock + quantity;
        }
        public void AddInitialInventory()
        {
            lemons = new Lemons();
            sugar = new Sugar();
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
        }

        public virtual void RemoveInventory()
        {
            stock = stock - 1;
        }
        public void MakeBatch()
        {
            while (lemons.stock > 0 && sugar.stock > 0)
            {
                supply = supply + 1;
                UpdateStock();
            }

            Console.WriteLine($"You have made enough to sell {supply} glasses of lemonade.");
            Console.WriteLine();
        }
        public void DisplayInventory()
        {
            Console.WriteLine("-----Inventory-----");
            Console.WriteLine($"Lemons: {lemons.stock} lemons");
            Console.WriteLine($"Sugar: {sugar.stock} cups of sugar");
            Console.WriteLine();
        }
    }
}
