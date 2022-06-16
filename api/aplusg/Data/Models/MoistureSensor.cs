using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
	public class MoistureSensor : ISensor
	{
		[Required]
		public int CurrentMoistureValue { get; set; }
		public int Id {get; set; }
		public DateTime Date { get; set; }
	}
}
