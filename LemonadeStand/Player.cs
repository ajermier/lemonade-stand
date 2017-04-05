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
        //public string name;
        public Inventory inventory;
        public Recipe recipe;
        private double unitCost;
        public double Balance { get { return balance; } set { value = balance; } }

        //constructors
        public Player()
        {
            balance = 20;
            inventory = new Inventory();
            inventory.AddInitialInventory();
            recipe = new Recipe(inventory);

            //name = getName();
        }

        //methods
        public void GetIngredients()
        {
            DisplayBalance();
            while (!CheckFundsAvail(inventory.lemons.Buy(), Lemons.unitPrice));
            inventory.lemons.AddNewInventory(inventory.lemons.buyAmount);
            Debit(inventory.lemons.buyAmount, Lemons.unitPrice);
            DisplayBalance();
            while (!CheckFundsAvail(inventory.sugar.Buy(), Sugar.unitPrice));
            inventory.sugar.AddNewInventory(inventory.sugar.buyAmount);
            Debit(inventory.sugar.buyAmount, Sugar.unitPrice);
            DisplayBalance();
            while (!CheckFundsAvail(inventory.cups.Buy(), Cups.unitPrice));
            inventory.cups.AddNewInventory(inventory.cups.buyAmount);
            Debit(inventory.cups.buyAmount, Cups.unitPrice);
            Console.WriteLine();
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
            else if(price < GetUnitCost())
            {
                string unit = string.Format("{0:N2}", Math.Round(GetUnitCost() * 100) / 100);
                Console.WriteLine($"Your price must be above ${unit}, otherwise you won't make any money.");
                GetPrice();
            }
            Console.WriteLine();
        }
        public double GetUnitCost()
        {
            double lemonsUnitCost = inventory.lemons.GetUnitCost();
            double sugarUnitCost = inventory.sugar.GetUnitCost();
            double cupUnitCost = inventory.cups.GetUnitCost();

            unitCost = lemonsUnitCost + sugarUnitCost + cupUnitCost;

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
            string bal = string.Format("{0:N2}", Math.Round(balance * 100) / 100);
            Console.WriteLine("-----balance-----");
            Console.WriteLine($" ${bal}");
            Console.WriteLine();
        }
    }
}
