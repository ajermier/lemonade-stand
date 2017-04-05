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
        public double price;
        private double balance;
        private Recipe recipe;
        //public string name;
        public Inventory inventory;
        private double unitCost;
        public double Balance { get { return balance; } set { value = balance; } }

        //constructors
        public Player()
        {
            recipe = new Recipe();
            balance = 20;
            inventory = new Inventory();
            inventory.AddInitialInventory();
            //name = getName();
        }

        //methods
        public void GetIngredients()
        {
            {
                inventory.lemons.AddNewInventory();
                while (CheckFundsAvail(inventory.lemons.quantity, Lemons.unitPrice) == false)
                {
                    inventory.lemons.AddNewInventory();
                }
                Debit(inventory.lemons.quantity, Lemons.unitPrice);

                inventory.sugar.AddNewInventory();
                while (CheckFundsAvail(inventory.sugar.quantity, Sugar.unitPrice) == false)
                {
                    inventory.sugar.AddNewInventory();
                }
                Debit(inventory.sugar.quantity, Sugar.unitPrice);
            }
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
            Console.WriteLine();
        }
        public double GetUnitCost()
        {
            double lemonsUnitCost = inventory.lemons.GetUnitCost();
            double sugarUnitCost = inventory.sugar.GetUnitCost();

            unitCost = lemonsUnitCost + sugarUnitCost;

            return unitCost;
        }
        public bool CheckFundsAvail(int quantity, double unitPrice)
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
        }

        public void Credit(double amount)
        {
            balance = balance + amount;
        }

        public void DisplayBalance()
        {
            string display = string.Format("{0:N2}", Math.Round(balance * 100) / 100);
            Console.WriteLine("-----balance-----");
            Console.WriteLine($" ${display}");
            Console.WriteLine();
        }
    }
}
