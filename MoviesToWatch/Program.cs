using MoviesToWatch.App.Abstract;
using MoviesToWatch.App.Concrete;
using MoviesToWatch.App.Managers;
using MoviesToWatch.Domain.Entity;
using System;

namespace MoviesToWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            MovieManager movieManager = new MovieManager(actionService);

            Console.WriteLine("=====================");
            Console.WriteLine("=  Movies to watch  =");
            Console.WriteLine("=====================");
            Console.WriteLine("==     v.1.1.0     ==");
            Console.WriteLine("=====================");
            Console.WriteLine();

            
            var mainMenu = actionService.GetMenuActionsByMenuName("Main");

            while (true)
            {

                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operatnion = Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                switch (operatnion.KeyChar)
                {
                    case '1':
                        var newId = movieManager.AddNewMovie();
                        break;
                    case '2':
                        movieManager.RemoveMovie();
                        break;
                    case '3':
                        movieManager.SetMovieWatched();
                        break;
                    case '4':
                        movieManager.ListWatchedMovies();
                        break;
                    case '5':
                        Console.WriteLine("Thank you for using our app. Hope to see you again soon!");
                        return;
                    default:
                        Console.WriteLine("Chosen action do not exist. Please try again...");
                        break;



                }
                Console.Clear();


            }


        }


    }

}
