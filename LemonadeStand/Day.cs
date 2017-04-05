using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        //member variables
        private double dailySales;
        private double dailyProfit;
        private double dailyExpense;
        private int cupCount;
        private List<Customer> customerList;

        public double DailyProfit { get { return dailyProfit; } }

        //constructors
        public Day(Player player, Weather weather, int dayOfWeek)
        {
            GetDay(player, weather, dayOfWeek);
        }

        //methods
        public void GetDay(Player player, Weather weather, int i)
        {
            player.inventory.supply = 0;

            weather.GetActualWeather(i);
            player.inventory.DisplayInventory();
            player.GetIngredients();
            player.inventory.MakeBatch();
            player.inventory.DisplayInventory();
            GetExpense(player);
            player.GetPrice();

            GetCustomerList(i, weather);
            GetSales(player, customerList);
            DisplaySales(player);
            DisplayExpense();
            DisplayProfit();
            player.Credit(dailySales);
        }
        private void GetSales(Player player, List<Customer> customerList)
        {
            dailySales = 0;
            cupCount = 0;
            int i = 0;
            while (player.inventory.CheckSupply() == true && i < customerList.Count)
            {
                if (customerList[i].maxPrice >= player.price)
                {
                    dailySales = dailySales + (player.price * customerList[i].thirst);
                    player.inventory.supply = player.inventory.supply - customerList[i].thirst;
                    cupCount = cupCount + customerList[i].thirst;
                }
                i++;
            }
        }
        private void GetCustomerList(int day, Weather weather)
        {
            customerList = new List<Customer>();
            Random number = new Random();
            int baseDemand = weather.CalculateBaseDemand(day);

            for (int i = 0; i < baseDemand; i++)
            {
                customerList.Add(new Customer(number, baseDemand));
            }
        }
        private void GetExpense(Player player)
        {
            dailyExpense = 0;
            dailyExpense = player.inventory.supply * player.GetUnitCost();
        }
        private void DisplaySales(Player player)
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
            Console.WriteLine("-----Profit/Loss-----");
            Console.WriteLine($" ${profit}");
            Console.WriteLine();
        }
    }
}
