using System;
using System.Collections.Generic;

namespace UESAN.Jobs.Core.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Tipo { get; set; }

    public bool? Estado { get; set; }

    public string? Correo { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Empresa> Empresa { get; set; } = new List<Empresa>();

    public virtual ICollection<Postulante> Postulante { get; set; } = new List<Postulante>();
}
