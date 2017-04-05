using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    static class UserInterface
    {
        //member variables

        //methods
        public static void GetBeginGame()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-----------------LEMONADE STAND------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Welcome to Thirstopia, where the weather is crazy,");
            Console.WriteLine("but when its nice people will crave lemonade.");
            Console.WriteLine();

            Console.WriteLine("Try your luck at becoming a leomonade stand tycoon!");
            Console.WriteLine();

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------DIRECTIONS--------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("You will start the week off with 20 dollars cash and ");
            Console.WriteLine("a prime location that will get you up to 100 customers");
            Console.WriteLine("on sunny hot days. Your goal is to make as much money ");
            Console.WriteLine("as possible by the end of the week. If at the end of ");
            Console.WriteLine("any day your balance is below $5 the game is over.");
            Console.WriteLine();
        }
        public static void GetEndGame(double totalProfit)
        {
            if(totalProfit > 20)
            {
                Console.WriteLine("Congradulations. You managed to turn a profit of");
                Console.WriteLine($"${totalProfit} this week!");
            }
            else if(totalProfit < 20)
            {
                double endBalance = 20 - totalProfit;
                Console.WriteLine($"Well, you made it to the end of the week with a loss of {endBalance}");
                Console.WriteLine("...maybe brush up on your economics.");
            }
        }
    }
}
