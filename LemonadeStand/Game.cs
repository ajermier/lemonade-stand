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

        //constructors
        public Game()
        {
            weather = new Weather();
            player = new Player();


        }

        //methods
        public void GetDay()
        {            
            for (int i = 0; i <7; i++)
            {
                weather.GetActualWeather(i);
                player.DisplayInventory();
                player.AddNewInventory();
                player.GetPrice();

                GetCustomerList(i);

                GetSales();

                Console.WriteLine($"You made {dailySales} today!");

                Console.WriteLine();
            }

        }
        private void GetSales()
        {
            dailySales = 0;
            for(int i = 0; i < customerList.Count; i++)
            {
                if (customerList[i].maxPrice >= player.price)
                {
                    dailySales = dailySales + player.price;
                }
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
    }
}
