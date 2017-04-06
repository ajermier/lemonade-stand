using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        //member variables
        int[] tempModifier;
        double[] precipModifier;
        public int[] tempForecast;
        public string[] precipForecast;
        public int[] baseDemand;

        Random number;

        //constructors
        public Weather()
        {

            tempModifier = new int[7];
            tempForecast = new int[7];
            precipModifier = new double[7];
            precipForecast = new string[7];
            baseDemand = new int[7];

            GetWeekForecast();
        }

        //methods
        private void GetTemperature(Random number, int i)
        {
            int num = number.Next(5, 10);
            int num2 = number.Next(0, 10);

            switch (num)
            {
                case 5:
                    tempForecast[i] = num * 10 + num2;
                    tempModifier[i] = -80;
                    break;
                case 6:
                    tempForecast[i] = num * 10 + num2;
                    tempModifier[i] = -60;
                    break;
                case 7:
                    tempForecast[i] = num * 10 + num2;
                    tempModifier[i] = -40;
                    break;
                case 8:
                    tempForecast[i] = num * 10 + num2;
                    tempModifier[i] = -20;
                    break;
                case 9:
                    tempForecast[i] = num * 10 + num2;
                    tempModifier[i] = 0;
                    break;
            }
        }

        private void GetChancePrecip(Random number, int i)
        {
            int num = number.Next(0, 5);

            switch (num)
            {
                case 0:
                    precipModifier[i] = 1;
                    precipForecast[i] = "0%";
                    break;
                case 1:
                    precipModifier[i] = 0.9;
                    precipForecast[i] = "25%";
                    break;
                case 2:
                    precipModifier[i] = 0.7;
                    precipForecast[i] = "50%";
                    break;
                case 3:
                    precipModifier[i] = 0.4;
                    precipForecast[i] = "75%";
                    break;
                case 4:
                    precipModifier[i] = 0.3;
                    precipForecast[i] = "100%";
                    break;
            }
        }

        public void GetWeekForecast()
        {
            Random number = new Random();

            Console.WriteLine("----------Weekly Weather Forcast----------");
            for (int i = 0; i < 7; i++)
            {
                GetTemperature(number, i);
                GetChancePrecip(number, i);
                Console.WriteLine($"Day {i + 1}: high of {tempForecast[i]} with a {precipForecast[i]} chance of rain.");
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to get started");
            Console.ReadLine();
        }

        public void GetActualWeather(int i)
        {
            Random number = new Random();

            int num = number.Next(0, 4);

            if (num == 1)
            {
                GetTemperature(number, i);
                Console.WriteLine($"...seems like the forecast was a little off for today.");
            }
            else if (num == 0)
            {
                GetChancePrecip(number, i);
                Console.WriteLine($"...seems like the forecast was a litte off for today.");
            }
            Console.WriteLine($"Today is a high of {tempForecast[i]} with a {precipForecast[i]} chance of rain.");
            Console.WriteLine();
        }

        public int CalculateBaseDemand(int i)
        {
            baseDemand[i] = Convert.ToInt32((100 + tempModifier[i]) * precipModifier[i]);

            return baseDemand[i];
        }
        public void DisplayCurrentWeather(int i)
        {
            Console.WriteLine($"Today is a high of {tempForecast[i]} with a {precipForecast[i]} chance of rain.");
            Console.WriteLine();
        }
    }
}
