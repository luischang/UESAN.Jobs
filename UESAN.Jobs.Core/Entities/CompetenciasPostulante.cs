using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class CompetenciasPostulante
{
	public int IdCompetenciaPostulante { get; set; }

	public int IdCompetencia { get; set; }

	public int IdPostulante { get; set; }

	public bool? Estado { get; set; }

	public virtual Competencias IdCompetenciaNavigation { get; set; } = null!;

	public virtual Postulante IdPostulanteNavigation { get; set; } = null!;
}
