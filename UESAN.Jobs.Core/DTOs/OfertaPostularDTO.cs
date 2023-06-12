using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Jobs.Core.DTOs
{
	public class OfertaPostularDTO
	{
		public int IdOfertaPostular { get; set; }

		public int? IdOferta { get; set; }

		public int? IdPostulante { get; set; }

		public DateTime? Fecha { get; set; }

		public bool? Estado { get; set; }
	}

	public class OfertaPostularOfertaDTO 
	{
		public int IdOfertaPostular { get; set; }

		public OfertaDescDTO Oferta { get; set; }

		public PostulanteDescDTO Postulante { get; set; }

		public DateTime? Fecha { get; set; }

		public bool? Estado { get; set; }
	}

	public class OfertaPostularUpdateDTO 
	{
		public int IdOfertaPostular { get; set; }

		public int? IdOferta { get; set; }

		public int? IdPostulante { get; set; }

		public DateTime? Fecha { get; set; }

		public bool? Estado { get; set; }

	}

	public class OfertaPostularInsertDTO
	{
		public OfertOfertaPostularInsertDTO Oferta { get; set; }

		public PostulanteOfertaPostularInsertDTO Postulante { get; set; }
		public DateTime? Fecha { get; set; }

	}

	public class OfertaPostularPostulanteDTO 
	{
		public int IdOfertaPostular { get; set; }
		public PostulanteDescripcionDTO PostulanteDescripcion { get; set; }

	}
}
