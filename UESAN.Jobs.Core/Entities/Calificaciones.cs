using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Calificaciones
{
	public int IdEmpresa { get; set; }

	public int IdPostulante { get; set; }

	public int? Calificacion { get; set; }

	public bool? Estado { get; set; }

	public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

	public virtual Postulante IdPostulanteNavigation { get; set; } = null!;
}
