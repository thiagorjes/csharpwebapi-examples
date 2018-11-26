using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public partial class State
    {
        [Key]
        public int IdState { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public int IdCountry { get; set; }
        public Country IdCountryNavigation { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
