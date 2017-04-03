using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        //member variables
        private double balance;
        public string name;
        Lemons lemons;
        Sugar sugar;

        //constructors
        public Player()
        {
            balance = 20;
            AddInitialInventory();
            //name = getName();
        }

        //methods
        public void AddInitialInventory()
        {
            lemons = new Lemons();
            while (CheckFundsAvail(lemons.quantity, lemons.unitPrice) == false)
            {
                lemons.AddNewInventory();
            }
            Debit(lemons.quantity, lemons.unitPrice);

            sugar = new Sugar();
            while (CheckFundsAvail(sugar.quantity, sugar.unitPrice) == false)
            {
                sugar.AddNewInventory();
            }
            Debit(sugar.quantity, sugar.unitPrice);
        }

        private bool CheckFundsAvail(int quantity, double unitPrice)
        {
            double total = unitPrice * quantity;

            if (total > balance)
            {
                Console.WriteLine("Not enough cash to make this purchase. Try again.");
                return false;
            }
            else return true;
        }

        private void Debit(int quantity, double unitPrice)
        {
            balance = balance - (unitPrice * quantity);
            Console.WriteLine("Cash balance = {0}", balance);
        }

    }
}
