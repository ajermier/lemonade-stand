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
        public double unitPrice;
        public double totalServingProportion;

        //constructors
        public Inventory()
        {
            totalServingProportion = 4;
        }

        //methods
        public virtual void AddNewInventory()
        {
            Console.WriteLine("Enter amount to add: ");
            int.TryParse(Console.ReadLine(), out quantity);
            stock = stock + quantity;
        }

        public virtual void RemoveInventory()
        {
            stock = stock - 1;
        }
    }
}
