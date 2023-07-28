using System;
using System.Collections.Generic;

namespace Empleados.Api.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int DepartamentoId { get; set; }

    public int Sueldo { get; set; }

    public DateTime FechaDeContrato { get; set; }

    public DateTime FechaDeRegistro { get; set; }

    public virtual Departamento Departamento { get; set; } = null!;
}
