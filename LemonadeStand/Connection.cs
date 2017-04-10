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

        public static List<string> saveNames;
        public static List<string> saveDates;
        public static List<int> saveIDs;

        public static string saveName;
        public static string playerName;
        public static double balance;
        public static double lemonStock;
        public static double lemonProp;
        public static double sugarStock;
        public static double sugarProp;
        public static int iceStock;
        public static int iceProp;
        public static int cupStock; 

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
        public static void SaveEndOfWeek(string saveName, string playerName, double balance, double lemonStock, double lemonProp, double sugarStock, double sugarProp, int iceStock, int iceProp, int cupStock)
        {
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = "Data Source=AJLAPTOP;Initial Catalog=LemonadeStand;Integrated Security=True";
                connect.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO SavedGames (saveName,playerName,balance,lemonStock,lemonProp,sugarStock,sugarProp,iceStock,iceProp,cupStock,saveDate) VALUES('{saveName}', '{playerName}', {balance}, {lemonStock}, {lemonProp}, {sugarStock}, {sugarProp}, {iceStock}, {iceProp}, {cupStock}, GETDATE());", connect);
                command.ExecuteNonQuery();
                Console.WriteLine("Saving Game...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while saving:" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public static void GetSavedGames()
        {
            saveNames = new List<string>();
            saveIDs = new List<int>();
            saveDates = new List<string>();
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = "Data Source=AJLAPTOP;Initial Catalog=LemonadeStand;Integrated Security=True";
                connect.Open();
                SqlCommand command = new SqlCommand("SELECT saveName, saveDate, saveID FROM SavedGames;", connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    saveNames.Add(read["saveName"].ToString());
                    saveIDs.Add(Convert.ToInt32(read["saveID"]));
                    saveDates.Add(read["saveDate"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while loading:" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        public static void Load(int saveID)
        {
            try
            {
                connect = new SqlConnection();
                connect.ConnectionString = "Data Source=AJLAPTOP;Initial Catalog=LemonadeStand;Integrated Security=True";
                connect.Open();
                SqlCommand command = new SqlCommand($"SELECT playerName,balance,lemonStock,lemonProp,sugarStock,sugarProp,iceStock,iceProp,cupStock FROM SavedGames WHERE saveID = {saveID};", connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    playerName = read["playerName"].ToString();
                    balance = Convert.ToDouble(read["balance"]);
                    lemonStock = Convert.ToDouble(read["lemonStock"]);
                    lemonProp = Convert.ToDouble(read["lemonProp"]);
                    sugarStock = Convert.ToDouble(read["sugarStock"]);
                    sugarProp = Convert.ToDouble(read["sugarProp"]);
                    iceStock = Convert.ToInt32(read["iceStock"]);
                    iceProp = Convert.ToInt32(read["iceProp"]);
                    cupStock = Convert.ToInt32(read["cupStock"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong while loading, check save game ID:" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }
    }

}
