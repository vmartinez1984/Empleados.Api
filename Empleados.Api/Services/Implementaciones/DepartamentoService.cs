using Empleados.Api.Models;
using Empleados.Api.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Empleados.Api.Services.Implementaciones
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly EmpleadosContext _context;

        public DepartamentoService(EmpleadosContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> GetAll()
        {
            List<Departamento> departamentos;

            departamentos = await _context.Departamentos.ToListAsync();

            return departamentos;

        }
    }
}
