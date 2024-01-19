using MoviesToWatch.App.Concrete;
using MoviesToWatch.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesToWatch.App.Managers
{
    public class MovieManager
    {
        private readonly MenuActionService _actionService;
        private MovieService _movieService;

        public MovieManager(MenuActionService actionService)
        {
            _movieService = new MovieService();
            _actionService = actionService;
        }
        public int AddNewMovie()
        {
            var addNewMovieMenu = _actionService.GetMenuActionsByMenuName("MovieType");
            int[] typeId =  new int [2];

            for (int i = 0; i < 2; i++)
            {
                if (i == 0) Console.WriteLine("\nWhat is the primary movie type?\n");
                else if (i == 1) Console.WriteLine("\nWhat is the secondary movie type?\n");

                for (int j = 0; j < addNewMovieMenu.Count; j++)
                {
                    Console.WriteLine($"{addNewMovieMenu[j].Id}. {addNewMovieMenu[j].Name}");
                }

                var operation = Console.ReadKey();
                Int32.TryParse(operation.KeyChar.ToString(), out typeId[i]);

            }


            Console.WriteLine("\nPlease insert movie name:\n");
            var name = Console.ReadLine();
            var lastId = _movieService.GetLastId();
            Movie movie = new Movie(lastId + 1, name, typeId[0], typeId[1]);
            _movieService.AddItem(movie);
            return movie.Id;
        }
        public void RemoveMovie()
        {
            int movieId = 0;
            
            Console.WriteLine("\nPlease select movie to remove:\n");
            _movieService.ShowAllMovies();
            var movieToDelete = Console.ReadLine();
            Int32.TryParse(movieToDelete, out movieId);
            _movieService.DeleteMovieById(movieId);

        }

        public void SetMovieWatched()
        {
            int movieId = 0;

            Console.WriteLine("\nPlease select watched movie:\n");
            _movieService.ShowAllUnwatchedMovies();
            var movieWatched = Console.ReadLine();
            Int32.TryParse(movieWatched, out movieId);
            _movieService.MarkMovieAsWatched(movieId);

        }

        public void ListWatchedMovies()
        {
            var addNewMovieMenu = _actionService.GetMenuActionsByMenuName("MovieType");
            int typeId = 0;

            Console.WriteLine("\nWhat movie type do you want to watch?\n");

            for (int i = 0; i < addNewMovieMenu.Count; i++)
            {
                Console.WriteLine($"{addNewMovieMenu[i].Id}. {addNewMovieMenu[i].Name}");
            }

            var operation = Console.ReadKey();
            Int32.TryParse(operation.KeyChar.ToString(), out typeId);
            Console.WriteLine("\n");
            _movieService.ShowWatchedMoviesByType(typeId);
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();

        }

    }
}
