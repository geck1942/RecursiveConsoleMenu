using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            // get the menu object from the DataModel\MenuData.json file
            // note the file properties are set as 'content / Copy always'
            var menu = MenuDataSource.GetMenu();
            // Draw and ask the user to pick an item from the menu
            string itemUID = menu.PickUID();

            Console.WriteLine("user selected " + itemUID);
            switch (itemUID)
            {
                case "dog":
                    // implements action for dog
                    break;
                case "cat":
                    // implements action for dog
                    break;
                // ... and so on...
            }
            Console.ReadLine();
        }
    }
}
