﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApplicationCore.Entities
{
    [Table("Genre")]
    public class Genre
    {
 
        public int Id { get; set; }
        [MaxLength(64)] //applied to Name when place on top
        public string Name { get; set; }

        //Navigation
        public ICollection<Movie> Movies { get; set; }

    }
}
