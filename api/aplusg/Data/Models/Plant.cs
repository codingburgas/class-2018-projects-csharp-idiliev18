using aplusg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        [MaxLength(128)]
        public string LatinName { get; set; }
        [Required]
        public int VegetativePeriod { get; set; }
        [Required]
        public int RequieredAmountOfWater { get; set; }
        public string ImagePath { get; set; }

        // Navigation properties
		public User User { get; set; }
		public int UserId { get; set; }
    }
}
