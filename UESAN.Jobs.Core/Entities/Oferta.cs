﻿using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Oferta
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

	public int? NumeroPostulantes { get; set; }

	public virtual ICollection<CompetenciasOferta> CompetenciasOferta { get; set; } = new List<CompetenciasOferta>();

	public virtual Empresa? IdEmpresaNavigation { get; set; }

	public virtual ICollection<OfertaPostular> OfertaPostular { get; set; } = new List<OfertaPostular>();
}
