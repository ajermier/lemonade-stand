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

        private double totalProfit;

        //constructors
        public Game()
        {
            UserInterface.GetBeginGame();
            player = new Player();
            GetWeek();
        }

        //methods
        public void GetWeek()
        {
            weather = new Weather();

            int i = 0;         
            while (CheckForLoser(player)==false && i < 7)
            {
                day = new Day(player, weather, i);
                i++;
                totalProfit = totalProfit + day.DailyProfit;
            }
            UserInterface.GetEndGame(totalProfit);
            RestartQuitGame();
        }
        private bool CheckForLoser(Player player)
        {
            if (player.Balance <= 5)
            {
                Console.WriteLine("You ran out of money, better luck next time.");
                Console.WriteLine();
                return true;
            }
            else return false;
        }
        private void RestartQuitGame()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine(" 1- continue playing into another week");
            Console.WriteLine(" 2- start over");
            Console.WriteLine(" 3- quit");
            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    GetWeek();
                    break;
                case "2":
                    Console.Clear();
                    Game game = new Game();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Enter '1', '2', or '3'.");
                    break;                    
            }
        }
    }
}
