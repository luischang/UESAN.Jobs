using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class PostulanteDTO
	{
		public int IdPostulante { get; set; }

		public int? IdUsuario { get; set; }

		public string? Nombre { get; set; }

		public string? Dni { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }

		public byte[]? Cv { get; set; }

		public byte[]? Certificados { get; set; }
	}

	public class PostulanteInsertDTO 
	{
		public UsuarioAuthRequestDTO UsuarioInsert { get; set; }
		public string? Nombre { get; set; }

		public string? Dni { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }

		public byte[]? Cv { get; set; }

		public byte[]? Certificados { get; set; }

	}

	public class PostulanteUsuarioDTO 
	{
		public string? Nombre { get; set; }

		public string? Dni { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }

		public byte[]? Cv { get; set; }

		public byte[]? Certificados { get; set; }

		public UsuarioDescripcionDTO UsuarioDescripcionDTO { get; set; }

	}


}
