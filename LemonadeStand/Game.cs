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

        private double totalWeeklyProfit;
        private double maxDailyProfit;

        //constructors
        public Game()
        {
            UserInterface.GetBeginGame();
            player = new Player();
            GetWeek();
        }

        //methods
        private void GetWeek()
        {
            totalWeeklyProfit = 0;
            maxDailyProfit = 0;
            weather = new Weather();

            int i = 0;         
            while (CheckForLoser(player)==false && i < 7)
            {
                day = new Day(player, weather, i);
                i++;
                totalWeeklyProfit = totalWeeklyProfit + day.DailyProfit;
                if(maxDailyProfit < day.DailyProfit)
                {
                    maxDailyProfit = day.DailyProfit;
                }
            }
            UserInterface.GetEndGame(totalWeeklyProfit, i);
            Connection.AddScore(player.name, totalWeeklyProfit, maxDailyProfit);
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
