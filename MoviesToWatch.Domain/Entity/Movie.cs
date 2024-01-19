using MoviesToWatch.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesToWatch.Domain.Entity
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public int Type1ID { get; set; }
        public int Type2ID { get; set; }
        public Boolean Watched { get; set; } = false;

        public Movie (int id, string name, int type1Id, int type2Id)
        {
            Id = id;
            Name = name;
            Type1ID = type1Id;
            Type2ID = type2Id;
        }


    }
}
