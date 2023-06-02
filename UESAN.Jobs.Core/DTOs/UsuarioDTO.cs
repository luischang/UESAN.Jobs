using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class UsuarioDTO
	{
		public int IdUsuario { get; set; }

		public string? Tipo { get; set; }

		public bool? Estado { get; set; }

		public string? Correo { get; set; }

		public string? Password { get; set; }
	}

	public class UsuarioAuthenticationDTO 
	{
		public string? Correo { get; set; }
		public string? Password { get; set; }
	}


}
