using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplusg.Data.Models
{
	public interface ISensor
	{
		public int Id { get; set; }
		public DateTime Date { get; set; }
	}
}
