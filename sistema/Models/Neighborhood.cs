using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public partial class Neighborhood
    {
        [Key]
        public int IdNeighborhood { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int IdCity { get; set; }
        public City IdCityNavigation { get; set; }
        public ICollection<AccessToken> AccessToken { get; set; }
       
    }
}
