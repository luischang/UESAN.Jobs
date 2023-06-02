using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class OfertaDTO
	{
		public int IdOferta { get; set; }
		public int? IdEmpresa { get; set; }
		public string? Puesto { get; set; }
		public string? Descripcion { get; set; }
		public string? Requisitos { get; set; }
		public byte[]? Certificados { get; set; }
		public string? Funciones { get; set; }
		public string? Ubicacion { get; set; }
		public string? Modalidad { get; set; }
		public string? Estado { get; set; }
	}
}
