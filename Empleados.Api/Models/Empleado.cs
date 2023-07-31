using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleados.Api.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;


    public int Sueldo { get; set; }

    public DateTime FechaDeContrato { get; set; }

    public DateTime FechaDeRegistro { get; set; }= DateTime.Now;

    public int DepartamentoId { get; set; }
    
    [ForeignKey("DepartamentoId")]
    public virtual Departamento Departamento { get; set; } = null!;
}
