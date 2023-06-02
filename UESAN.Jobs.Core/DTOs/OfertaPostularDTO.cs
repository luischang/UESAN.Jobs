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
}
