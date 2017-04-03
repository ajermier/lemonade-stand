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
        public double unitPrice;

        //constructors
        public Inventory()
        {
        }

        //methods
        public virtual int AddNewInventory()
        {
            Console.WriteLine("Enter amount to add: ");
            int.TryParse(Console.ReadLine(), out quantity);
            return quantity;
        }

        public int AddToInventory()
        {
            quantity = quantity + AddNewInventory();

            return quantity;

        }

        public virtual void RemoveInventory(double amount)
        {
        }
    }
}
