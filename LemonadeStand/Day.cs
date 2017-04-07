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
        public Day(Player player, Weather weather, int dayOfWeek, Random number)
        {
            GetDay(player, weather, dayOfWeek, number);
        }
 
        //methods
        public void GetDay(Player player, Weather weather, int i, Random number)
        {
            player.inventory.supply = 0;

            DisplayDayStart(i+1);
            player.recipe.PromptForRecipe(player.inventory);
            weather.GetActualWeather(i, number);
            player.inventory.DisplayInventory();
            player.GetIngredients();

            DisplayDayStart(i + 1);
            player.inventory.DisplayInventory();
            weather.DisplayCurrentWeather(i);
            player.inventory.MakeBatch(player.inventory.PromptForBatch());
            player.inventory.DisplayInventory();
            GetExpense(player);
            player.GetPrice();

            DisplayDayStart(i + 1);
            GetCustomerList(i, weather);
            GetSales(player, customerList);
            player.Credit(dailySales);
            DisplayDaySummary(player, i+1);

            if(i < 6 && player.Balance >= 5)
            {
                Console.Write("Press Enter to continue to next day.");
                Console.ReadLine();
            }
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
        private void DisplayDayStart(int day)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"----------------------DAY {day}----------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();

        }
        private void DisplayDaySummary(Player player, int day)
        {
            Console.WriteLine($"--------------END OF DAY {day} SUMMARY--------------");
            DisplaySales(player);
            DisplayExpense();
            DisplayProfit();
            player.DisplayBalance();
        }
    }
}
