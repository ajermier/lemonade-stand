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
                player.DisplayInventory();
                player.DisplayBalance();
                player.AddNewInventory();
                player.MakeBatch();
                GetExpense();
                player.GetPrice();

                GetCustomerList(i);
                GetSales();
                DisplayExpense();
                DisplayProfit();

            }
        }
        private void GetSales()
        {
            dailySales = 0;
            int i = 0;
            while(player.supply > 0 && i < customerList.Count)
            {
                if (customerList[i].maxPrice >= player.price)
                {
                    dailySales = dailySales + player.price;
                    player.supply = player.supply - 1;
                    if (customerList[i].thirst == 2)
                    {
                        dailySales = dailySales + player.price;
                        player.supply = player.supply - 1;
                    }               
                }
                i++;
            }
            Console.WriteLine($"You made ${dailySales} today!");
            player.Credit(dailySales);
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
            dailyExpense = player.supply * player.unitCost;
        }

        private void DisplayExpense()
        {
            string display = string.Format("{0:N2}", Math.Round(dailyExpense * 100) / 100);
            Console.WriteLine("-----Expense-----");
            Console.WriteLine($" ${dailyExpense}");
            Console.WriteLine();
        }

        private void DisplayProfit()
        {
            dailyProfit = dailySales - dailyExpense;
            string display = string.Format("{0:N2}", Math.Round(dailyProfit * 100) / 100);
            Console.WriteLine("-----Profit-----");
            Console.WriteLine($" ${dailyProfit}");
            Console.WriteLine();
        }
    }
}
