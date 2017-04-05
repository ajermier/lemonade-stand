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
        public Recipe(Inventory inventory)
        {
            PromptForRecipe(inventory);
        }
        //methods
        public void PromptForRecipe(Inventory inventory)
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
            ReadAnswerYN(inventory);
            Console.WriteLine();
        }
        public void ReadAnswerYN(Inventory inventory)
        {
            switch (Console.ReadLine())
            {
                case "y":
                    GetNewRecipe(inventory);
                    Console.WriteLine();
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Error: Please enter 'y' or 'n'.");
                    ReadAnswerYN(inventory);
                    break;
            }
        }
        public void GetNewRecipe(Inventory inventory)
        {
            Console.WriteLine("Total parts must equal 1.5:");
            Console.Write("How many parts sugar (default 0.5)? ");
            double.TryParse(Console.ReadLine(), out inventory.sugar.unitProportion);
            Console.Write("How many parts lemon (default 1.0)? ");
            double.TryParse(Console.ReadLine(), out inventory.lemons.unitProportion);

            if (inventory.sugar.unitProportion + inventory.lemons.unitProportion != 1.5)
            {
                GetNewRecipe(inventory);
            }
        }
    }
}
