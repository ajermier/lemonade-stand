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
                SqlCommand command = new SqlCommand($"INSERT INTO HighScores (playerName, weeklyProfit, dailyProfit) VALUES ('{name}', {totalWeeklyProfit*100}, {maxDailyProfit*100});", connect);
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
                SqlCommand command = new SqlCommand("SELECT TOP 10 playerName, weeklyProfit, dailyProfit FROM HighScores ORDER BY weeklyProfit DESC;", connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    names.Add(read["playerName"].ToString());
                    highWeeklyProfit.Add(Convert.ToDouble(read["weeklyProfit"])/100);
                    highDailyProfit.Add(Convert.ToDouble(read["dailyProfit"])/100);
                }
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
