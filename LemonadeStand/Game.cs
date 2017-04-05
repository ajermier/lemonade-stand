using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //member variables  
        private Player player;
        private Weather weather;
        private List<Customer> customerList;
        private double dailySales;
        private double dailyExpense;
        private double dailyProfit;
        private int cupCount;

        //constructors
        public Game()
        {
            player = new Player();
            weather = new Weather();
        }

        //methods
        public void GetDay()
        {            
            for (int i = 0; i <7; i++)
            {
                weather.GetActualWeather(i);
                player.inventory.DisplayInventory();
                player.DisplayBalance();
                player.GetIngredients();
                player.inventory.MakeBatch();
                GetExpense();
                Console.WriteLine($"It costs {player.GetUnitCost()} to make one cup" );
                player.GetPrice();

                GetCustomerList(i);
                GetSales();
                DisplaySales();
                DisplayExpense();
                DisplayProfit();
                player.Credit(dailyProfit);
            }
        }
        private void GetSales()
        {
            dailySales = 0;
            cupCount = 0;
            int i = 0;
            while(player.inventory.CheckSupply() == true && i < customerList.Count)
            {
                if (customerList[i].maxPrice >= player.price)
                {
                    dailySales = dailySales + player.price;
                    player.inventory.supply = player.inventory.supply - 1;
                    cupCount++;
                    if (customerList[i].thirst == 2)
                    {
                        dailySales = dailySales + player.price;
                        player.inventory.supply = player.inventory.supply - 1;
                        cupCount++;
                    }               
                }
                i++;
            }
        }
        private void GetCustomerList(int day)
        {
            customerList = new List<Customer>();
            Random number = new Random();
            int baseDemand = weather.CalculateBaseDemand(day);

            for (int i = 0; i < baseDemand; i++)
            {
                customerList.Add(new Customer(number, baseDemand));
            }
        }

        private void GetExpense()
        {
            dailyExpense = player.inventory.supply * player.GetUnitCost();
        }
        private void DisplaySales()
        {
            string price = string.Format("{0:N2}", Math.Round(player.price * 100) / 100);
            Console.WriteLine($"You sold {cupCount} cups today at a price of ${price} each.");
            Console.WriteLine();
            string sales = string.Format("{0:N2}", Math.Round(dailySales * 100) / 100);
            Console.WriteLine("-----Sales-----");
            Console.WriteLine($" ${sales}");
            Console.WriteLine();
        }

        private void DisplayExpense()
        {
            string expense = string.Format("{0:N2}", Math.Round(dailyExpense * 100) / 100);
            Console.WriteLine("-----Expense-----");
            Console.WriteLine($" ${expense}");
            Console.WriteLine();
        }

        private void DisplayProfit()
        {
            dailyProfit = dailySales - dailyExpense;
            string profit = string.Format("{0:N2}", Math.Round(dailyProfit * 100) / 100);
            Console.WriteLine("-----Profit-----");
            Console.WriteLine($" ${profit}");
            Console.WriteLine();
        }
    }
}
