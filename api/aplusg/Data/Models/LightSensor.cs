using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
	public class LightSensor : ISensor
	{
		public string CurrentLightValue { get; set; }
		public int Id { get; set; }
		public DateTime Date { get; set; }
	}
}
