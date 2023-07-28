namespace Empleados.Api.Dtos
{
    public class EmpleadoDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string DepartamentoNombre { get; set; }

        public int DepartamentoId { get; set; }

        public int Sueldo { get; set; }

        public string FechaDeContrato { get; set; }
    }
}
