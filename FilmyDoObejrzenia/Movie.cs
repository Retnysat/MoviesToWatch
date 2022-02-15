using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmyDoObejrzenia
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type1ID { get; set; }
        public int Type2ID { get; set; }
        public Boolean Watched { get; set; } = false;


    }
}
