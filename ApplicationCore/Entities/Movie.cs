using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }    // ? means it will set datatype to null for that datatype
        public decimal? Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }

        public decimal? Rating { get; set; }

        //Navigation to Trailer with relationship of many to one
        public ICollection<Trailer> Trailers { get; set; }
        //Navigation to Genre with relationship of many to many
        public ICollection<Genre> Genres { get; set; }

        //Navigation to Cast with relationship of many to many
        public ICollection<MovieCast> MovieCasts { get; set; }
        
        //Navigation to Crew with relationship of many to many
        public ICollection<MovieCrew> MovieCrews { get; set; }

        //Navigation to Review with relationship of many to one
        public ICollection<Review> Reviews { get; set; }

        public ICollection<Purchase> Purchases { get; set; }

        public ICollection<Favorite> Favorites { get; set; }
    }
}
