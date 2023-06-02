using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class OfertaPostular
{
	public int IdOfertaPostular { get; set; }

	public int? IdOferta { get; set; }

	public int? IdPostulante { get; set; }

	public DateTime? Fecha { get; set; }

	public bool? Estado { get; set; }

	public virtual Oferta? IdOfertaNavigation { get; set; }

	public virtual Postulante? IdPostulanteNavigation { get; set; }
}
