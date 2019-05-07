using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNumber11
{
    class Movie
    {
        //Data members
        private string _title;
        private string _category;

        //Properties
        public string Title {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string Category {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        //Constructors
        public Movie(string t, string c)
        {
            Title = t;
            Category = c;
        }

        public Movie() { }

        public static List<Movie> GetDataFromFile()
        {
            List<Movie> movieList = new List<Movie>();

            if (File.Exists(@"movieList.bin"))
            {
                using(BinaryReader br = new BinaryReader(File.Open(@"movieList.bin", FileMode.Open)))
                {
                    int count = br.ReadInt32();

                    for(int i = 0; i < count; i++)
                    {
                        string cat = br.ReadString();
                        string tit = br.ReadString();
                        Movie m = new Movie(tit, cat);
                        movieList.Add(m);
                    }
                }

            }
            return movieList;
        }

        public static void WriteDataToFile(List<Movie> mL)
        {
            using(FileStream streamIt = new FileStream(@"movieList.bin", FileMode.Create))
            {
                using(BinaryWriter bw = new BinaryWriter(streamIt))
                {
                    bw.Write(mL.Count);

                    foreach(Movie item in mL)
                    {
                        bw.Write(item.Category);
                        bw.Write(item.Title);
                    }
                }
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Would you like to...\n" +
                "1) List movies\n" +
                "2) Add a movie\n" +
                "3) Delete a movie\n" +
                "4) Quit");
        }

        public static void DisplayListMenu()
        {
            Console.WriteLine("What category are you interested in?\n" +
                "1) Animated\n" +
                "2) Drama\n" +
                "3) Horror\n" +
                "4) Sci-fi\n" +
                "5) All categories\n" +
                "6) Return to the Main Menu");
        }

        public static void DisplayCategoriesMenu()
        {
            Console.WriteLine("\nWhat category is it?\n" +
                "1) Animated\n" +
                "2) Drama\n" +
                "3) Horror\n" +
                "4) Sci-fi\n" +
                "5) Quit and return to the Main Menu");
        }

        public static void ListMovies(List<Movie> mL)
        {
            Console.Clear();
            DisplayListMenu();
            int choice = Validator.GetMenuChoice(6, "Enter your choice: ");
            switch (choice)
            {
                case 1:
                    ListCategory(mL, "animated" );
                    break;
                case 2:
                    ListCategory(mL, "drama");
                    break;
                case 3:
                    ListCategory(mL, "horror");
                    break;
                case 4:
                    ListCategory(mL, "scifi");
                    break;
                case 5:
                    ListCategory(mL, "animated drama horror scifi");
                    break;
                case 6: //Return to the Main Menu
                    break;
                default: break;
            }
        }

        public static void PrintHeaders()
        {
            string header1 = string.Format("{0,5}{1,-10}{2,-100}"," No. ","Category","Title");
            string header2 = string.Format("{0,5}{1,-10}{2,-100}", " *** ", "********", "*********************");
            Console.WriteLine(header1);
            Console.WriteLine(header2);
        }

        public static string FormatCategory(string cat)
        {
            switch (cat)
            {
                case "animated": return "Animated";
                case "drama": return "Drama";
                case "horror": return "Horror";
                case "scifi": return "Sci-Fi";
                default:return "";
            }
        }

        public static void ListCategory(List<Movie> mL, string cat)
        {
            PrintHeaders();

            int count = 1;

            foreach(Movie item in mL)
            {
                if(cat.Contains(item.Category))
                {
                    Console.WriteLine(string.Format("{0,5}{1,-10}{2,-100}",
                        $" {count} ", $"{FormatCategory(item.Category)}", $"{item.Title}"));
                    count++;
                }
            }
        }

        public static void AddMovie(List<Movie> mL)
        {
            Console.Clear();
            Console.Write("Enter the name of the movie." +
                "\n(leave it blank to quit): ");
            string movieName = Validator.GetMovieName();
            if(movieName != "1a2b3x4G5t6H")
            {
                DisplayCategoriesMenu();
                int choice = Validator.GetMenuChoice(5, "Enter your choice: ");
                Movie m = new Movie();
                switch (choice)
                {
                    case 1:
                        m.Title = movieName;
                        m.Category = "animated";
                        mL.Add(m);
                        break;
                    case 2:
                        m.Title = movieName;
                        m.Category = "drama";
                        mL.Add(m);
                        break;
                    case 3:
                        m.Title = movieName;
                        m.Category = "horror";
                        mL.Add(m);
                        break;
                    case 4:
                        m.Title = movieName;
                        m.Category = "scifi";
                        mL.Add(m);
                        break;
                    case 5:
                        break;
                    default:break;
                }
            }
        }

        public static void DeleteMovie(List<Movie> mL)
        {
            Console.Clear();
            ListCategory(mL, "animated drama horror scifi");
            Console.WriteLine("Which movie would you like to delete? ");
            int choice = Validator.GetMenuChoice(mL.Count, "Enter your choice: ");
            Console.WriteLine($"You are about to delete {mL[choice -1].Title}. Proceed? (y/n): ");
            bool proceed = Validator.GetYesNo();
            if (proceed)
            {
                mL.RemoveAt(choice - 1);
            }
        }
    }
}
