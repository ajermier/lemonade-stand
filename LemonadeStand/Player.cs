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
        public string name;
        public Inventory inventory;
        public Recipe recipe;
        private double balance;
        private double unitCost;
        public double Balance { get { return balance; } set { value = balance; } }

        //constructors
        public Player()
        {
            name = GetPlayerName();
            balance = 20;
            inventory = new Inventory();
            inventory.AddInitialInventory();
            recipe = new Recipe(inventory);
        }
        public Player(int saveID)
        {
            Connection.Load(saveID);
            name = Connection.playerName;
            balance = Connection.balance;

            inventory = new Inventory();
            inventory.AddInitialInventory();
            recipe = new Recipe(inventory);

            inventory.lemons.stock = Connection.lemonStock;
            inventory.lemons.unitProportion = Connection.lemonProp;
            inventory.sugar.stock = Connection.sugarStock;
            inventory.sugar.unitProportion = Connection.sugarProp;
            inventory.iceCubes.stock = Connection.iceStock;
            inventory.iceCubes.unitProportion = Connection.iceProp;
            inventory.cups.stock = Connection.cupStock;
        }

        //methods
        public void GetIngredients()
        {
            Console.WriteLine("The first thing we have to do is buy some ingredients:");
            Console.WriteLine();

            DisplayBalance();
            while (!CheckFundsAvail(inventory.lemons.Buy(), Lemons.unitPrice));
            inventory.lemons.AddNewInventory(inventory.lemons.buyAmount);
            Debit(inventory.lemons.buyAmount, Lemons.unitPrice);
            DisplayBalance();
            while (!CheckFundsAvail(inventory.sugar.Buy(), Sugar.unitPrice));
            inventory.sugar.AddNewInventory(inventory.sugar.buyAmount);
            Debit(inventory.sugar.buyAmount, Sugar.unitPrice);
            DisplayBalance();
            while (!CheckFundsAvail(inventory.iceCubes.Buy(), IceCubes.unitPrice));
            inventory.iceCubes.AddNewInventory(inventory.iceCubes.buyAmount);
            Debit(inventory.iceCubes.buyAmount, IceCubes.unitPrice);
            DisplayBalance();
            while (!CheckFundsAvail(inventory.cups.Buy(), Cups.unitPrice));
            inventory.cups.AddNewInventory(inventory.cups.buyAmount);
            Debit(inventory.cups.buyAmount, Cups.unitPrice);
            DisplayBalance();
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
            double iceUnitCost = inventory.iceCubes.GetUnitCost();

            unitCost = lemonsUnitCost + sugarUnitCost + cupUnitCost + iceUnitCost;

            return unitCost;
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
        public string GetPlayerName()
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.Write("You must enter a name:");
                name = Console.ReadLine();
            }
            Console.WriteLine();

            return name;
        }
    }
}
