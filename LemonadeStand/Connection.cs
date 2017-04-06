using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Connection
    {
        //member variables
        public static SqlConnection connect;
        public static List<string> names;
        public static List<double> highWeeklyProfit;
        public static List<double> highDailyProfit;
       
        //constructors

        //methods
        public static void AddScore(string name, double totalWeeklyProfit, double maxDailyProfit)
        {
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = "Data Source=AJLAPTOP;Initial Catalog=LemonadeStand;Integrated Security=True";
                connect.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO HighScores (playerName, weeklyProfit, dailyProfit) VALUES ('{name}', {totalWeeklyProfit}, {maxDailyProfit});", connect);
                command.ExecuteNonQuery();
                Console.WriteLine("Updating record boards...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while accessing the record boards:" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public static void GetHighScores()
        {
            names = new List<string>();
            highWeeklyProfit = new List<double>();
            highDailyProfit = new List<double>();

            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = "Data Source=AJLAPTOP;Initial Catalog=LemonadeStand;Integrated Security=True";
                connect.Open();
//                SqlCommand command = new SqlCommand($"", connect);
//                command.ExecuteNonQuery();
//                Console.WriteLine("Updating record boards...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while accessing the record boards:" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }
    }

}
