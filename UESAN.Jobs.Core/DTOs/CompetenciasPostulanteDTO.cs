using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class CompetenciasPostulanteDTO
	{
		public int IdCompetencia { get; set; }

		public CompetenciasDescripcionDTO Competencias { get; set; }

		public PostulanteDescripcionDTO Postulante { get; set; }
	}

	public class CompetenciasPostulanteInsertDTO 
	{
		public int IdCompetencia { get; set; }

		public int IdPostulante { get; set; }
	}
}
