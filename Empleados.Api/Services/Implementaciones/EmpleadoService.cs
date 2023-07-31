using Empleados.Api.Models;
using Empleados.Api.Services.Contrato;
using Microsoft.EntityFrameworkCore;

namespace Empleados.Api.Services.Implementaciones
{
    public class EmpleadoService: IEmpleadoService
    {
        private readonly EmpleadosContext _context;

        public EmpleadoService(EmpleadosContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Empleado empleado)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();

            return empleado.Id;
        }

        public async Task Delete(Empleado entity)
        {
            _context.Empleados.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Empleado>> GetAll()
        {
            return await _context
                .Empleados
                .Include(x=> x.Departamento)
                .ToListAsync();
        }

        public async Task<Empleado> GetById(int id)
        {
            return await _context.Empleados
                .Include(x=> x.Departamento)
                .Where(x=> x.Id == id).FirstOrDefaultAsync();  
        }

        public async Task Update(Empleado entity)
        {
            _context.Empleados.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
