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
        private string saveName;

        //constructors
        public Game()
        {
            UserInterface.GetBeginGame(); //for new game
            player = new Player();
            number = new Random();
            GetWeek(number);
        }
        public Game(int saveID) //for load game
        {
            player = new Player(saveID);

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

            while (CheckForLoser(player) == false && i < 7)
            {
                day = new Day(player, weather, i, number2);
                i++;
                totalWeeklyProfit = totalWeeklyProfit + day.DailyProfit;
                if (maxDailyProfit < day.DailyProfit)
                {
                    maxDailyProfit = day.DailyProfit;
                }
            }

            GetEndGame(totalWeeklyProfit, i);
            Connection.AddScore(player.name, totalWeeklyProfit, maxDailyProfit);

            if (player.Balance > 5)
            {
                DisplayContinueMenu();
                //ask if they want to save
            }
            else
            {
                UserInterface.GetMainMenu();
            }
        }
        private void GetEndGame(double totalProfit, int day)
        {
            string total = string.Format("{0:N1}", Math.Round(totalProfit * 100) / 100);

            if (totalProfit > 20)
            {
                Console.WriteLine("Congradulations. You managed to turn a profit of");
                Console.WriteLine($"${total} this week!");
                Console.WriteLine();
            }
            else if (totalProfit < 0)
            {
                Console.WriteLine($"You made it through day {day} with a loss of ${total}.");
                Console.WriteLine("...maybe brush up on your economics.");
                Console.WriteLine();
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
        private void DisplayContinueMenu() //add save option
        {
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------END OF WEEK-------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("------        1- View Leaderboard          ------");
            Console.WriteLine("------        2- Continue Playing          ------");
            Console.WriteLine("------        3- Save Game                 ------");
            Console.WriteLine("------        4- Return to Main Menu       ------");
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
                    SaveGame(GetSaveGameName());
                    DisplayContinueMenu();
                    break;

                case "4":
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
        private void LoadGame(int saveID)
        {
            Connection.Load(saveID);
        }
        private void SaveGame(string saveName)
        {
            Connection.SaveEndOfWeek(saveName, player.name, player.Balance, player.inventory.lemons.stock, player.inventory.lemons.unitProportion, player.inventory.sugar.stock, player.inventory.sugar.unitProportion, Convert.ToInt32(player.inventory.iceCubes.stock), player.inventory.iceCubes.unitProportion, Convert.ToInt32(player.inventory.cups.stock));
        }
        private string GetSaveGameName()
        {
            Console.Write("Name your save game: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You must name your save game.");
                GetSaveGameName();
            }
            return name;
        }
    }
}
