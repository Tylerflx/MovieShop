using System;
namespace ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal? Rating { get; set; }
        public string ReviewText { get; set; }

        //Navigation One to Many
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
