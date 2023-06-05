using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Jobs.Core.Entities;

namespace UESAN.Jobs.Core.DTOs
{
	public class OfertaDTO
	{
		public int IdOferta { get; set; }

		public int? IdEmpresa { get; set; }

		public string? Puesto { get; set; }

		public string? Descripcion { get; set; }

		public string? Requisitos { get; set; }

		public string? Certificados { get; set; }

		public string? Funciones { get; set; }

		public string? Ubicacion { get; set; }

		public string? Modalidad { get; set; }

		public bool? Estado { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public virtual Empresa? IdEmpresaNavigation { get; set; }

		public virtual ICollection<OfertaPostular> OfertaPostular { get; set; } = new List<OfertaPostular>();
	}

	public class OfertaEmpresaDTO
	{
		public int IdOferta { get; set; }
		public string? Puesto { get; set; }

		public string? Descripcion { get; set; }

		public string? Requisitos { get; set; }

		public string? Certificados { get; set; }

		public string? Funciones { get; set; }

		public string? Ubicacion { get; set; }

		public string? Modalidad { get; set; }

		public bool? Estado { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public EmpresaDescDTO Empresa { get; set; }



	}

	public class OfertaUpdateDTO
	{
		public int IdOferta { get; set; }

		public int? IdEmpresa { get; set; }

		public string? Puesto { get; set; }

		public string? Descripcion { get; set; }

		public string? Requisitos { get; set; }

		public string? Certificados { get; set; }

		public string? Funciones { get; set; }

		public string? Ubicacion { get; set; }

		public string? Modalidad { get; set; }

		public bool? Estado { get; set; }

		public DateTime? FechaCreacion { get; set; }


	}

	public class OfertaInsert
	{
		public string? Puesto { get; set; }

		public string? Descripcion { get; set; }

		public string? Requisitos { get; set; }

		public string? Certificados { get; set; }

		public string? Funciones { get; set; }

		public string? Ubicacion { get; set; }

		public string? Modalidad { get; set; }

		public DateTime? FechaCreacion { get; set; }
		public EmpresaOfertaInsertDTO Empresa { get; set; }


	}

	public class OfertaDescDTO
	{
		public int IdOferta { get; set; }

		public string? Descripcion { get; set; }

	}
	
	public class OfertOfertaPostularInsertDTO 
	{
		public int IdOferta { get; set; }

		public string? Descripcion { get; set; }

	}
	
}
