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
                player.AddNewInventory();
                player.GetPrice();

                GetCustomerList(i);
                GetSales();
            }
        }
        private void GetSales()
        {
            dailySales = 0;
            int i = 0;
            while(player.CheckStock() == true && i < customerList.Count)
            {
                if (customerList[i].maxPrice >= player.price)
                {
                    dailySales = dailySales + player.price;
                    player.UpdateStock();               
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
    }
}
