using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class CalificacionesDTO
	{
		public EmpresaDescDTO Empresa { get; set; }
		public PostulanteDescripcionDTO Postulante { get; set; }
		public int? Calificacion { get; set; }
	}

	public class CalificacionesInsertDTO 
	{
		public int IdEmpresa { get; set; }

		public int IdPostulante { get; set; }

		public int? Calificacion { get; set; }
	}
}
