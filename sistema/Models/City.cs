using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public partial class City
    {
        [Key]
        public int IdCity { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int IdState { get; set; }       
        public State IdStateNavigation { get; set; }
        public ICollection<Neighborhood> Neighborhoods { get; set; }
    }
}
