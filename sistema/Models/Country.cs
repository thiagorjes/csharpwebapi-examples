using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sistema.Models
{
    public partial class Country
    {
        [Key]
        public int IdCountry { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public ICollection<State> States { get; set; }
    }
}
