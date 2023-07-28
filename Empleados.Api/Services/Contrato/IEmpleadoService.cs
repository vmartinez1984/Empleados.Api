using Empleados.Api.Models;

namespace Empleados.Api.Services.Contrato
{
    public interface IEmpleadoService
    {
        Task<int> Add(Empleado empleado);

        Task<Empleado> GetById(int id);

        Task<List<Empleado>> GetAll();

        Task Update(Empleado entity);

        Task Delete(Empleado entity); 
    }
}
