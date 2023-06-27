using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class ArchivosDTO
	{
		public int IdArchivo { get; set; }

		public int? IdPostulante { get; set; }

		public string? NombreArchivo { get; set; }

		public string? Tipo { get; set; }

		public bool? Estado { get; set; }
	}

	public class GetArchivosDTO
	{
		public int? IdPostulante { get; set; }
	}

	public class InsertArchivosDTO
	{
		public int? IdPostulante { get; set; }

		public string? NombreArchivo { get; set; }

		public string? Tipo { get; set; }

	}
	public class GenerarArchivoDTO
	{
		public int? IdPostulante { get; set; }
		public string? Tipo { get; set; }
	}
	public class NombresArchivosDTO
	{
		public string? NombreArchivo { get; set; }
	}
}
