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
        }
        //methods
        private void GetRecipe(Inventory inventory)
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
        }
        public void PromptForRecipe(Inventory inventory)
        {
            Console.Write("Do you want to change your recipe today? (y or n): ");
            ReadAnswerYN(inventory);
        }
        private void ReadAnswerYN(Inventory inventory)
        {
            switch (Console.ReadLine())
            {
                case "y":
                    GetNewLemonadeRecipe(inventory);
                    break;
                case "n":
                    Console.WriteLine();
                    break;
                default:
                    Console.Write("Error: Please enter 'y' or 'n': ");
                    ReadAnswerYN(inventory);
                    break;
            }
        }
        private void GetNewLemonadeRecipe(Inventory inventory)
        {
            Console.WriteLine();
            GetRecipe(inventory);
            GetLemonadeIngredients(inventory);
            GetIce(inventory);
        }
        private void GetLemonadeIngredients(Inventory inventory)
        {
            Console.WriteLine("Total parts must equal 1.5:");
            Console.Write("How many parts sugar (default 0.5)? ");
            while(!double.TryParse(Console.ReadLine(), out inventory.sugar.unitProportion) || inventory.sugar.unitProportion < 0)
            {
                Console.Write("Enter a positive number only: ");
            }
            Console.Write("How many parts lemon (default 1.0)? ");
            while (!double.TryParse(Console.ReadLine(), out inventory.lemons.unitProportion) || inventory.lemons.unitProportion < 0)
            {
                Console.Write("Enter a positive number only: ");
            }

            Console.WriteLine();

            if (inventory.sugar.unitProportion + inventory.lemons.unitProportion != 1.5)
            {
                Console.WriteLine("The proportions you entered did not equal 1.5. Try again.");
                Console.WriteLine();
                GetLemonadeIngredients(inventory);
            }
            else if (inventory.sugar.unitProportion < 0.1 || inventory.lemons.unitProportion < 0.1)
            {
                Console.WriteLine("You cannot go below 0.1 parts for any ingredient, otherwise");
                Console.WriteLine("Your lemonade will be far too sweet or lemony.");
                Console.WriteLine();
                GetLemonadeIngredients(inventory);
            }
        }

        private void GetIce(Inventory inventory)
        {
            Console.Write("How many ice cubes in each cup (default 3)? ");
            while(!int.TryParse(Console.ReadLine(), out inventory.iceCubes.unitProportion) || inventory.iceCubes.unitProportion < 1)
            {
                Console.Write("Enter a positive whole number only: ");
            }

            if (inventory.iceCubes.unitProportion < 1 || inventory.iceCubes.unitProportion > 5)
            {
                Console.WriteLine("You must have between 1 and 5 ice cubes per cup.");
                GetIce(inventory);
            }
        }
    }
}
