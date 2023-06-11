using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class CompetenciasDTO
	{
		public int IdCompetencia { get; set; }
		public string? Descripcion { get; set; }
		public bool? Estado { get; set; }
	}

	public class CompetenciasInsertDTO 
	{
		public string? Descripcion { get; set; }
	}

	public class CompetenciasUpdateDTO
	{
		public int IdCompetencia { get; set; }
		public string? Descripcion { get; set; }
	}
}
