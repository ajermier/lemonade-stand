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
            totalProfit = 0;
            weather = new Weather();

            int i = 0;         
            while (CheckForLoser(player)==false && i < 7)
            {
                day = new Day(player, weather, i);
                i++;
                totalProfit = totalProfit + day.DailyProfit;
            }
            UserInterface.GetEndGame(totalProfit, i);
            if(player.Balance > 5)
                ContinueToNewWeek();
            else
                UserInterface.RestartQuitGame();
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

        private void ContinueToNewWeek()
        {
            if (UserInterface.ReadAnswerYN("Do you want to continue on to another week? (y or n): ") == true)
            {
                GetWeek();
            }
            else UserInterface.RestartQuitGame();
        }
    }
}
