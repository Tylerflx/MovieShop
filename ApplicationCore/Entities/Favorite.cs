using System;
namespace ApplicationCore.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public string MovieId { get; set; }
        public string UserId { get; set; }

        //Navigation
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
