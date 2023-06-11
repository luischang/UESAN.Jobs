using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Competencias
{
	public int IdCompetencia { get; set; }

	public string? Descripcion { get; set; }

	public bool? Estado { get; set; }
}
