using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
    internal class MoistureSensor
    {
        public int Id { get; set; }
        public int CurrentMoistureValue { get; set; }
        public DateTime Date { get; set; }
    }
}
