﻿using System;
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

		

	}

	public class PostulanteInsertDTO 
	{
		
		public string? Nombre { get; set; }

		public string? Dni { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }

		public UsuarioAuthRequestDTO? UsuarioInsert { get; set; }

	}

	public class PostulanteUsuarioDTO 
	{
		public int IdPostulante { get; set; }
		public string? Nombre { get; set; }

		public string? Dni { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }


		public UsuarioDescripcionDTO? Usuario { get; set; }

	}

	public class PostulanteUpdateDTO 
	{
		public int IdPostulante { get; set; }

		public string? Nombre { get; set; }

		public string? Dni { get; set; }

		public string? Direccion { get; set; }

		public string? Telefono { get; set; }

		public UsuarioUpdate? UpdateUsuario { get; set; }


	}

	public class PostulanteValidacion
	{
		public int IdPostulante { get; set; }

		public UsuarioValidacion Usuario { get; set; }
	}

	public class PostulanteOfertaPostularInsertDTO 
	{
		public int IdPostulante { get; set; }

	}

	public class PostulanteDescripcionDTO 
	{
		public int IdPostulante { get; set; }
		public string? Nombre { get; set; }
	}




}
