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
            PromptForRecipe();
            supply = 0;
            AddNewInventory();
            //name = getName();
        }

        //methods
        public void PromptForRecipe()
        {
            Console.WriteLine("----------Recipe----------");
            Console.WriteLine("You can change your recipe if you want. The default is:");
            Console.WriteLine("  <>2 parts lemon juice");
            Console.WriteLine("  <>1 part sugar");
            Console.WriteLine("  <>5 parts water");
            Console.WriteLine("Because lemonade stands are highly regulated for water ");
            Console.WriteLine("content you can only adjust the ratio of lemon juice to ");
            Console.WriteLine("sugar (2:1 by default).");
            Console.WriteLine();
            Console.Write("Do you want to change from the tried and true default recipe? (y or n): ");
            ReadAnswerYN();
        }

        public void ReadAnswerYN()
        {
            switch (Console.ReadLine())
            {
                case "y":
                    GetNewRecipe();
                    Console.WriteLine();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Error: Please enter 'y' or 'n'.");
                    ReadAnswerYN();
                    break;
            }
        }

        public void GetNewRecipe()
        {
            Console.WriteLine("Total parts must equal 1.5:");
            Console.Write("How many parts sugar (default 0.5)? ");
            double.TryParse(Console.ReadLine(), out sugar.unitProportion);
            Console.Write("How many parts lemon (default 1.0)? ");
            double.TryParse(Console.ReadLine(), out lemons.unitProportion);

            if (sugar.unitProportion + lemons.unitProportion > 2)
            {
                GetNewRecipe();
            }
        }
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

        public bool CheckStock()
        {
            if(lemons.stock > 0 && sugar.stock > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Your ran out of supplies before the end of the day.");
                return false;
            }
        }

        public void UpdateStock()
        {
            lemons.RemoveInventory();
            sugar.RemoveInventory();
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

        public void Credit(double amount)
        {
            balance = balance + amount;
            Console.WriteLine("Cash balance = {0}", balance);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("-----Inventory-----");
            Console.WriteLine($"Lemons: {lemons.stock} lemons");
            Console.WriteLine($"Sugar: {sugar.stock} cups of sugar");
        }

    }
}
