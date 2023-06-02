using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class EmpresaDTO
	{
		public int IdEmpresa { get; set; }

		public int? IdUsuario { get; set; }

		public string? Nombre { get; set; }

		public string? Ruc { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }

	}

	 
}
