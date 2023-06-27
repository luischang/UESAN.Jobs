using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Archivos
{
	public int IdArchivo { get; set; }

	public int? IdPostulante { get; set; }

	public string? NombreArchivo { get; set; }

	public string? Tipo { get; set; }

	public bool? Estado { get; set; }

	public virtual Postulante? IdPostulanteNavigation { get; set; }
}
