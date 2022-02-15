using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmyDoObejrzenia
{
    internal class MovieService
    {

        public List<Movie> movies;

        public MovieService()
        {
            movies = new List<Movie>();
        }

        public List<Movie> GetAllItems()
        {
            return movies;

        }

        public void ShowAllMovies()
        {
            foreach (var movie in movies)
            {
                Console.WriteLine($"{movie.Id}. {movie.Name}");
            }
        }

        public void ShowAllUnwatchedMovies()
        {
            foreach (var movie in movies)
            {
                if (!(movie.Watched)) Console.WriteLine($"{movie.Id}. {movie.Name}");
            }
        }

        public void AddNewMovie(int id, string name, int type_1, int type_2)
        {
            Movie movie = new Movie() { Id = id, Name = name, Type1ID = type_1, Type2ID = type_2 };
            movies.Add(movie);
        }

        public void GetMoviesByType(char type)
        {
            int typeID = 0;
            Int32.TryParse(type.ToString(), out typeID);
            foreach (var movie in movies)
            {
                if (((movie.Type1ID == typeID) || (movie.Type2ID == typeID) || (typeID == 6)) && (!(movie.Watched))) 
                {
                    Console.WriteLine($"{movie.Id}. {movie.Name}");
                }


            }
        }

        public int DajID()
        {
            int iD = 0;
            foreach (var movie in movies)
            {
                if (movie.Id > iD)
                {
                    iD = movie.Id;
                }


            }
            iD++;
            return iD;
        }

        public ConsoleKeyInfo MovieTypeView(MenuActionService actionService, int typeNumber)
        {
            var addNewMovieMenu = actionService.GetMenuActionsByMenuName("MovieType");

            if (typeNumber == 1) Console.WriteLine("Podaj główny typ filmu");
            else if (typeNumber == 2) Console.WriteLine("Podaj poboczny typ filmu");
            else if (typeNumber == 3) Console.WriteLine("Jaki typ filmu chcesz obejrzeć?");
            else Console.WriteLine("Błąd programu, skontaktuj się z producentem....");

            for (int i= 0; i < addNewMovieMenu.Count; i++)
            {
                Console.WriteLine($"{addNewMovieMenu[i].Id}. {addNewMovieMenu[i].Name}");   
            }

            var operation = Console.ReadKey();
            return operation;
        }

        public void AddNewMovie(string movieName, char movieType_1, char movieType_2)
        {
            int type1ID, type2ID;
            Int32.TryParse(movieType_1.ToString(), out type1ID);
            Int32.TryParse(movieType_2.ToString(), out type2ID);
            Movie movie = new Movie();
            AddNewMovie(DajID(), movieName, type1ID, type2ID);
        }

        public void DeleteMovie (int idToDelete)
        {
            foreach (var movie in movies)
            {
                if (movie.Id == idToDelete)
                {
                    movies.Remove(movie);
                    break;
                }    
            }
        }

        public void WatchedMovie(int idToDelete)
        {
            foreach (var movie in movies)
            {
                if (movie.Id == idToDelete)
                {
                    movie.Watched = true;
                }
            }
        }
    }
}
