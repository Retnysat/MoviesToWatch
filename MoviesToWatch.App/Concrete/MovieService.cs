using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesToWatch.App.Common;
using MoviesToWatch.Domain.Entity;

namespace MoviesToWatch.App.Concrete
{
    public class MovieService : BaseService<Movie>
    {

        public void ShowAllMovies()
        {
            foreach (var movie in Items.OrderBy(p => p.Id))
            {
                Console.WriteLine($"{movie.Id}. {movie.Name}");
            }
        }

        public void ShowAllUnwatchedMovies()
        {
            foreach (var movie in Items.OrderBy(p => p.Id))
            {
                if (!(movie.Watched)) Console.WriteLine($"{movie.Id}. {movie.Name}");
            }
        }

        public void ShowWatchedMoviesByType(int typeId)
        {
            //Int32.TryParse(type.ToString(), out typeID);
            foreach (var movie in Items.OrderBy(p => p.Id))
            {
                if (((movie.Type1ID == typeId) || (movie.Type2ID == typeId) || (typeId == 6)) && (!(movie.Watched))) 
                {
                    Console.WriteLine($"{movie.Id}. {movie.Name}");
                }
            }
        }

        public void DeleteMovieById (int movieId)
        {
            foreach (var movie in Items)
            {
                if (movie.Id == movieId)
                {
                    RemoveItem(movie);
                    break;
                }    
            }
        }

        public void MarkMovieAsWatched(int movieId)
        {
            foreach (var movie in Items)
            {
                if (movie.Id == movieId)
                {
                    movie.Watched = true;
                }
            }
        }
    }
}
