using System;

namespace FilmyDoObejrzenia
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);            
            
            Console.WriteLine("MustToWatch Films!!");
            Console.WriteLine("====================");
            Console.WriteLine("v. 1.0.0");
            Console.WriteLine("====================");
            Console.WriteLine("====================");
            Console.WriteLine();

            MovieService movieService = new MovieService();
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
                        Console.WriteLine("Podaj nazwę filmu:");
                        string movieName = Console.ReadLine();
                        Console.WriteLine();
                        var keyInfo1 = movieService.MovieTypeView(actionService, 1);
                        Console.WriteLine();
                        Console.WriteLine();
                        var keyInfo2 = movieService.MovieTypeView(actionService, 2);
                        Console.WriteLine();
                        movieService.AddNewMovie(movieName, keyInfo1.KeyChar, keyInfo2.KeyChar);
                        break;
                    case '2':
                        Console.WriteLine("Wskaż film do usunięcia:");
                        movieService.ShowAllMovies();
                        var movieIdToDelete = Console.ReadLine();
                        int idToDelete;
                        Int32.TryParse(movieIdToDelete, out idToDelete);
                        movieService.DeleteMovie(idToDelete);
                        break;
                    case '3':
                        Console.WriteLine("Wskaż obejrzany film:");
                        movieService.ShowAllUnwatchedMovies();
                        var movieWatchedId = Console.ReadLine();
                        int idWatched;
                        Int32.TryParse(movieWatchedId, out idWatched);
                        movieService.WatchedMovie(idWatched);
                        break;
                    case '4':
                        var keyInfo3 = movieService.MovieTypeView(actionService, 1);
                        Console.Clear();
                        movieService.GetMoviesByType(keyInfo3.KeyChar);
                        Console.WriteLine();
                        Console.WriteLine("Naciśnij przycisk aby kontynuować...");
                        var tmp = Console.ReadKey();
                        break;
                    case '5':
                        Console.WriteLine("Dziękujemy za skorzystanie z naszej aplikacji!");
                        return;
                    default:
                        Console.WriteLine("Podana akcja nie istnieje. Proszę wybrać jeszcze raz!");
                        break;



                }
                Console.Clear();


            }


        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Dodaj nowy film", "Main");
            actionService.AddNewAction(2, "Usuń film z listy", "Main");
            actionService.AddNewAction(3, "Oznacz film jako obejrzany", "Main");
            actionService.AddNewAction(4, "Znajdź film na dzisiaj", "Main");
            actionService.AddNewAction(5, "Exit", "Main");

            actionService.AddNewAction(1, "Akcja", "MovieType");
            actionService.AddNewAction(2, "Komedia", "MovieType");
            actionService.AddNewAction(3, "Poważny", "MovieType");
            actionService.AddNewAction(4, "Thriller", "MovieType");
            actionService.AddNewAction(5, "Fantasy", "MovieType");
            actionService.AddNewAction(6, "Brak", "MovieType");
            return actionService;
        }
    }

}
