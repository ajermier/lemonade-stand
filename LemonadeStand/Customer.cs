using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        //member variables
        public double maxPrice;
        public int thirst;

        //constructors
        public Customer(Random number, int baseDemand)
        {
            thirst = 1;
            GetCustomerPrice(number, baseDemand);
        }

        //methods
        private void GetCustomerPrice(Random number, int baseDemand)
        {
            if (baseDemand >= 90)
            {
                double num1 = number.Next(250, 350)/100.0;
                double num2 = number.Next(0,100)/100.0;
                maxPrice = num1;
                if(num2 > 0.75)
                {
                    thirst = 2;
                }
            }
            else if(baseDemand >= 80 && baseDemand< 90)
            {
                double num1 = number.Next(200, 300) / 100.0;
                double num2 = number.Next(0,100)/100.0;
                maxPrice = num1;
                if (num2 > 0.80)
                {
                    thirst = 2;
                }
            }
            else if (baseDemand >= 70 && baseDemand < 80)
            {
                double num1 = number.Next(150, 250) / 100.0;
                double num2 = number.Next(0,100)/100.0;
                maxPrice = num1;
                if (num2 > 0.85)
                {
                    thirst = 2;
                }
            }
            else if (baseDemand >= 60 && baseDemand < 70)
            {
                double num1 = number.Next(100, 200) / 100.0;
                double num2 = number.Next(0,100)/100.0;
                maxPrice = num1;
                if (num2 > 0.90)
                {
                    thirst = 2;
                }
            }
            else if (baseDemand < 60)
            {
                double num1 = number.Next(50, 150) / 100.0;
                double num2 = number.Next(0,100)/100.0;
                maxPrice = num1;
                if (num2 > 0.95)
                {
                    thirst = 2;
                }
            }
        }
    }
}
