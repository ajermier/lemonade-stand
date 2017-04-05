using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe : Inventory
    {
        //member variables

        //constructors
        public Recipe()
        {
            PromptForRecipe();
        }
        //methods
        public void PromptForRecipe()
        {
            Console.WriteLine("----------Recipe----------");
            Console.WriteLine("You can change your recipe if you want. The default is:");
            Console.WriteLine("  <>2 parts lemon juice");
            Console.WriteLine("  <>1 part sugar");
            Console.WriteLine("  <>5 parts water");
            Console.WriteLine("Because lemonade stands are highly regulated for water ");
            Console.WriteLine("content you can only adjust the ratio of lemon juice to ");
            Console.WriteLine("sugar (2:1 by default).");
            Console.WriteLine();
            Console.Write("Do you want to change from the tried and true default recipe? (y or n): ");
            ReadAnswerYN();
            Console.WriteLine();
        }
        public void ReadAnswerYN()
        {
            switch (Console.ReadLine())
            {
                case "y":
                    GetNewRecipe();
                    Console.WriteLine();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Error: Please enter 'y' or 'n'.");
                    ReadAnswerYN();
                    break;
            }
        }
        public void GetNewRecipe()
        {
            Console.WriteLine("Total parts must equal 1.5:");
            Console.Write("How many parts sugar (default 0.5)? ");
            double.TryParse(Console.ReadLine(), out sugar.unitProportion);
            Console.Write("How many parts lemon (default 1.0)? ");
            double.TryParse(Console.ReadLine(), out lemons.unitProportion);

            if (sugar.unitProportion + lemons.unitProportion != 1.5)
            {
                GetNewRecipe();
            }
        }
    }
}
