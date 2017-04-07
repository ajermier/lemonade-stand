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
        public static void DisplayTitle()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-----------------LEMONADE STAND------------------");
            Console.WriteLine("-------------------------------------------------");
        }
        public static void GetBeginGame()
        {
            DisplayTitle();
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
        public static void GetMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------MAIN  MENU--------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("------        1- View Leaderboard          ------");
            Console.WriteLine("------        2- Start New Game            ------");
            Console.WriteLine("------        3- Quit                      ------");
            Console.WriteLine("-------------------------------------------------");
            MainMenuChoice(Console.ReadLine());
        }
        public static void MainMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Connection.GetHighScores();
                    DisplayTitle();
                    Console.WriteLine();
                    DisplayLeaderBoard(Connection.names, Connection.highWeeklyProfit, Connection.highDailyProfit);
                    GetBackToMenu();
                    break;
                case "2":
                    Console.Clear();
                    new Game();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine();
                    Console.Write("Invalid Input. Try Again: ");
                    MainMenuChoice(Console.ReadLine());
                    break;
            }
        }
        public static void GetBackToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("------        1- Back to Main Menu         ------");
            Console.WriteLine("-------------------------------------------------");
            BackToMenuChoice(Console.ReadLine());
        }
        public static void BackToMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    UserInterface.DisplayTitle();
                    UserInterface.GetMainMenu();
                    break;
                default:
                    Console.WriteLine();
                    Console.Write("Invalid Input. Try Again: ");
                    BackToMenuChoice(Console.ReadLine());
                    break;

            }
        }

        public static void GetEndGame(double totalProfit, int day)
        {
            if(totalProfit > 20)
            {
                Console.WriteLine("Congradulations. You managed to turn a profit of");
                Console.WriteLine($"${totalProfit} this week!");
                Console.WriteLine();
            }
            else if(totalProfit < 0)
            {
                Console.WriteLine($"You made it through day {day} with a loss of ${totalProfit}.");
                Console.WriteLine("...maybe brush up on your economics.");
                Console.WriteLine();
            }
        }
        public static bool ReadAnswerYN(string question)
        {
            Console.Write(question);
            switch (Console.ReadLine())
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    Console.Write("Error: Please enter 'y' or 'n': ");
                    ReadAnswerYN(question);
                    break;
            }
            return ReadAnswerYN(question);
        }
        public static void RestartQuitGame()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine(" 1- start over");
            Console.WriteLine(" 2- quit");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    Console.Clear();
                    Game game = new Game();
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Enter '1' or '2' only.");
                    RestartQuitGame();
                    break;
            }
        }
        public static void DisplayLeaderBoard(List<string> names, List<double> weeklyHigh, List<double> dailyHigh)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("------             LEADERBOARD             ------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("------                  MAX       MAX      ------");
            Console.WriteLine("------                 WEEKLY    DAILY     ------");
            Console.WriteLine("------       NAME      PROFIT    PROFIT    ------");
            Console.WriteLine("------      ----------------------------   ------");
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("------" + "  " + (i+1).ToString("00") + "." + "  " + TruncateString(names[i],8).PadRight(8) + "  " + "$" + (weeklyHigh[i]*100/100).ToString("0.00").PadRight(7) + "  " + "$" + (dailyHigh[i] * 100 / 100).ToString("0.00").PadRight(7) + "  " + "------");
            }
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
        }
        public static string TruncateString(string myString, int maxLength)
        {
            return myString.Length <= maxLength ? myString : myString.Substring(0, 8);
        }
    }
}
