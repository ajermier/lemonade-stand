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
        private int supply;
        public double price;
        private double balance;
        public string name;
        Lemons lemons;
        Sugar sugar;

        //constructors
        public Player()
        {
            balance = 20;
            lemons = new Lemons();
            sugar = new Sugar();
            supply = 0;
            AddNewInventory();
            //name = getName();
        }

        //methods
        public void AddNewInventory()
        {
            lemons.AddNewInventory();
            while (CheckFundsAvail(lemons.quantity, lemons.unitPrice) == false)
            {
                lemons.AddNewInventory();
            }
            Debit(lemons.quantity, lemons.unitPrice);

            sugar.AddNewInventory();
            while (CheckFundsAvail(sugar.quantity, sugar.unitPrice) == false)
            {
                sugar.AddNewInventory();
            }
            Debit(sugar.quantity, sugar.unitPrice);
        }

        public void GetPrice()
        {
            Console.Write("What price (per glass) do you want to sell your lemonade for today? $");
            double.TryParse(Console.ReadLine(), out price);
            if(price > 3.50)
            {
                Console.WriteLine("Are you nuts? Nobody will buy lemonade for that much! Lower your price.");
                GetPrice();
            }
            else if(price < 0.50)
            {
                Console.WriteLine("Your price must be over $0.50, otherwise you won't make any money.");
                GetPrice();
            }
        }

        public void CalculateSupply(Lemons lemons, Sugar sugar)
        {
            double lemonsCount = lemons.quantity;
            double sugarCount = sugar.quantity;

            while (lemonsCount > 0 && sugarCount > 0)
            {
                supply = supply + 1;
                lemonsCount = lemonsCount - (1.0/3);
                sugarCount = sugarCount - (1.0/6);
            }

            Console.WriteLine("You have enough ingredients for {0} cups of lemonade.", supply);
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

        private void Credit(double amount)
        {
            balance = balance + amount;
            Console.WriteLine("Cash balance = {0}", balance);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("-----Inventory-----");
            Console.WriteLine($"Lemons: {lemons.quantity} lemons");
            Console.WriteLine($"Sugar: {sugar.quantity} cups of sugar");
        }

    }
}
