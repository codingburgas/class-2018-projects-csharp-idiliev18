using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
    internal class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public int VegetativePeriod { get; set; }
        public int RequieredAmountOfWater { get; set; }
        public string ImagePath { get; set; }
        public int UserId { get; set; }
    }
}
