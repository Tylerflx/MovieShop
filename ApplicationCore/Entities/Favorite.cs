using System;
namespace ApplicationCore.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        //Navigation
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
