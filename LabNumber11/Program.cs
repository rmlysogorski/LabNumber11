using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNumber11
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runApp = true;
            while (runApp)
            {
                Console.Clear();
                Console.WriteLine(
                    "Welcome to the Movie List Application!\n");
                List<Movie> movieList = Movie.GetDataFromFile();
                movieList.Sort((a, b) => a.Title.CompareTo(b.Title));
                Console.WriteLine($"There are {movieList.Count} movies in this list.\n");
                Movie.DisplayMenu();
                int choice = Validator.GetMenuChoice(4, "Enter your choice: ");
                switch (choice)
                {
                    case 1:
                        Movie.ListMovies(movieList);
                        Pause();
                        break;
                    case 2:
                        Movie.AddMovie(movieList);
                        Pause();
                        break;
                    case 3:
                        Movie.DeleteMovie(movieList);
                        Pause();
                        break;
                    case 4:
                        runApp = false;
                        Console.Write("Are you sure you would like to quit? (y/n): ");
                        runApp = !Validator.GetYesNo();
                        break;
                    default: break;
                }

                Movie.WriteDataToFile(movieList);
            }
        }

        public static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
