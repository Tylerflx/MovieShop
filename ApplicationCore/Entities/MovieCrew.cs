using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCrew
    {
        public int CrewId { get; set; }
        public int MovieId { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }

        //relationship with 2 tables

        public Movie Movie { get; set; }
        public Crew Crew { get; set; }
    }
}
