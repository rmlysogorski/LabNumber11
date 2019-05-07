using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNumber11
{
    class Validator
    {
        public static int GetMenuChoice(int menuLength, string message)
        {
            Console.Write(message);
            if(!int.TryParse(Console.ReadLine(),out int choice))
            {
                Console.WriteLine($"Please enter a number betwen 1-{menuLength}");
                return GetMenuChoice(menuLength, message);
            }
            else if(choice < 1 || choice > menuLength)
            {
                Console.WriteLine($"Please enter a number betwen 1-{menuLength}");
                return GetMenuChoice(menuLength, message);
            }
            else
            {
                return choice;
            }
        }

        public static string GetMovieName()
        {
            string movieName = Console.ReadLine();
            if (movieName == string.Empty)
            {
                return "1a2b3x4G5t6H";
            }
            else
            {
                return movieName;
            }
        }

        public static bool GetYesNo(string opt1 = "y", string opt2 = "n")
        {
            string input = Console.ReadLine();
            if (input.ToLower() == opt1)
            {
                return true;
            }
            else if (input.ToLower() == opt2)
            {
                return false;
            }
            else
            {
                Console.Write($"Please enter {opt1} for yes or {opt2} for no: ");
                return GetYesNo(opt1, opt2);
            }
        }
    }
}
