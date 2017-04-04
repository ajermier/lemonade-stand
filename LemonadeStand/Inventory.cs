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
        private double stock;
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

        public void AddToInventory()
        {
            stock = stock + AddNewInventory();

        }

        public virtual void RemoveInventory(double amount)
        {
            stock = stock - amount;
        }
    }
}
