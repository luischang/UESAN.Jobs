using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Competencias
{
	public int IdCompetencia { get; set; }

	public string? Descripcion { get; set; }

	public bool? Estado { get; set; }

	public virtual ICollection<CompetenciasOferta> CompetenciasOferta { get; set; } = new List<CompetenciasOferta>();

	public virtual ICollection<CompetenciasPostulante> CompetenciasPostulante { get; set; } = new List<CompetenciasPostulante>();
}
