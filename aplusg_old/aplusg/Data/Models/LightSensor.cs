using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
    internal class LightSensor
    {
        public int Id { get; set; }
        public string CurrentLightValue { get; set; }
        public DateTime Date { get; set; }
    }
}
