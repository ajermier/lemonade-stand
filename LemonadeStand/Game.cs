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
        private Day day;
        private Random number;
        private Random number2;

        private double totalWeeklyProfit;
        private double maxDailyProfit;

        //constructors
        public Game()
        {
            UserInterface.GetBeginGame();
            player = new Player();
            number = new Random();
            GetWeek(number);
        }

        //methods
        private void GetWeek(Random number)
        {
            totalWeeklyProfit = 0;
            maxDailyProfit = 0;

            DisplayNewWeek();     
            weather = new Weather(number);
            number2 = new Random();
            int i = 0;

            while (CheckForLoser(player)==false && i < 7)
            {
                day = new Day(player, weather, i, number2);
                i++;
                totalWeeklyProfit = totalWeeklyProfit + day.DailyProfit;
                if(maxDailyProfit < day.DailyProfit)
                {
                    maxDailyProfit = day.DailyProfit;
                }
            }

            UserInterface.GetEndGame(totalWeeklyProfit, i);
            Connection.AddScore(player.name, totalWeeklyProfit, maxDailyProfit);

            if (player.Balance > 5)
            {
                DisplayContinueMenu();
            }
            else
            {
                UserInterface.GetMainMenu();
            }
        }
        private bool CheckForLoser(Player player)
        {
            if (player.Balance <= 5)
            {
                Console.WriteLine("You ran out of money, better luck next time. Better make sure you have enough for your uber ride home.");
                Console.WriteLine();
                return true;
            }
            else return false;
        }
        private void DisplayContinueMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------END OF WEEK-------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("------        1- View Leaderboard          ------");
            Console.WriteLine("------        2- Continue Playing          ------");
            Console.WriteLine("------        3- Quit                      ------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
            ContinueChoice(Console.ReadLine());
        }
        private void ContinueChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Connection.GetHighScores();
                    Console.WriteLine();
                    UserInterface.DisplayLeaderBoard(Connection.names, Connection.highWeeklyProfit, Connection.highDailyProfit);
                    Console.WriteLine();
                    Console.Write("Press enter to go BACK.");
                    Console.ReadKey();
                    Console.Clear();
                    DisplayContinueMenu();
                    break;
                case "2":
                    Console.Clear();
                    number = new Random();
                    GetWeek(number);
                    break;
                case "3":
                    UserInterface.GetMainMenu();
                    break;
                default:
                    Console.WriteLine();
                    Console.Write("Invalid Input. Try Again: ");
                    ContinueChoice(Console.ReadLine());
                    break;
            }
        }
        private void DisplayNewWeek()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("--------------------NEW WEEK---------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
        }
    }
}
