using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Empresa
{
	public int IdEmpresa { get; set; }

	public int? IdUsuario { get; set; }

	public string? Nombre { get; set; }

	public string? Ruc { get; set; }

	public string? Direccion { get; set; }

	public string? Telefono { get; set; }

	public virtual Usuario? IdUsuarioNavigation { get; set; }

	public virtual ICollection<Oferta> Oferta { get; set; } = new List<Oferta>();
}
