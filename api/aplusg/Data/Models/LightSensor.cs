using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
	public class LightSensor : ISensor
	{
		[Required]
		public string CurrentLightValue { get; set; }
		public int Id { get; set; }
		public DateTime Date { get; set; }
	}
}
