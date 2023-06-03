﻿using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Postulante
{
	public int IdPostulante { get; set; }

	public int? IdUsuario { get; set; }

	public string? Nombre { get; set; }

	public string? Dni { get; set; }

	public string? Direccion { get; set; }

	public string? Telefono { get; set; }

	public byte[]? Cv { get; set; }

	public byte[]? Certificados { get; set; }

	public virtual Usuario? IdUsuarioNavigation { get; set; }

	public virtual ICollection<OfertaPostular> OfertaPostular { get; set; } = new List<OfertaPostular>();
}