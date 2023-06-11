using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class CompetenciasOferta
{
	public int IdCompetencia { get; set; }

	public int IdOferta { get; set; }

	public bool? Estado { get; set; }

	public virtual Competencias IdCompetenciaNavigation { get; set; } = null!;

	public virtual Oferta IdOfertaNavigation { get; set; } = null!;
}
