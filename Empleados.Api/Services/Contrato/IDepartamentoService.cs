using Empleados.Api.Models;

namespace Empleados.Api.Services.Contrato
{
    public interface IDepartamentoService
    {
        Task<List<Departamento>> GetAll();
    }
}
