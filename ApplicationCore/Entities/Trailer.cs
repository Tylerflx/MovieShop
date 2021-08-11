using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        //foreign key
        //Many (Trailer) to 1 Movie
        public int MovieId { get; set; }
        //navigation property
        public Movie Movie { get; set; }    //create relationship to Movie Table
    }
}
