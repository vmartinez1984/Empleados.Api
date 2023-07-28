using System;
using System.Collections.Generic;

namespace Empleados.Api.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaDeRegistro { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
