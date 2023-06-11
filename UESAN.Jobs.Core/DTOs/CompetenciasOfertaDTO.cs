using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class CompetenciasOfertaDTO
	{
		public int IdCompetencia { get; set; }

		public int IdOferta { get; set; }

		public CompetenciasDescripcionDTO Competencias { get; set; }

		public OfertaDescripcionDTO Oferta { get; set;}
	}

	public class CompetenciasOfertasInsertDTO 
	{
		public int IdCompetencia { get; set; }

		public int IdOferta { get; set; }
	}

}
