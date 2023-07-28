using AutoMapper;
using Empleados.Api.Dtos;
using Empleados.Api.Helpers;
using Empleados.Api.Models;
using Empleados.Api.Services.Contrato;
using Empleados.Api.Services.Implementaciones;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmpleadosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddAutoMapper(typeof(EmpleadosMapper));
builder.Services.AddCors(options =>
{
    options.AddPolicy("Nueva politica", app =>
    {
        app.AllowAnyOrigin();
        app.AllowAnyHeader();
        app.AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/Departamentos", async (IDepartamentoService _departamentoService, IMapper _mapper) =>
{
    var departamentos = await _departamentoService.GetAll();
    var dtos = _mapper.Map<List<DepartamentoDto>>(departamentos);

    return Results.Ok(dtos);
});

app.MapGet("/Empleados", async (IEmpleadoService _service, IMapper _mapper) =>
{
    var entities = await _service.GetAll();
    var dtos = _mapper.Map<List<EmpleadoDto>>(entities);

    return Results.Ok(dtos);
});

app.MapPost("/Empleados", async (EmpleadoDto empleado, IEmpleadoService _service, IMapper _mapper) => {
    var entity = _mapper.Map<Empleado>(empleado);
    var id = await _service.Add(entity);

    return Results.Created($"/Empleados/{id}",new { Id= id} );
});

app.MapPut("/Empleados/{id}", async (int id, EmpleadoDto empleado, IEmpleadoService _service, IMapper _mapper) => {
    var entity = await _service.GetById(id);
    entity.Sueldo = empleado.Sueldo;
    entity.Nombre = empleado.Nombre;
    entity.DepartamentoId = empleado.DepartamentoId;
    entity.FechaDeContrato = DateTime.Parse(empleado.FechaDeContrato);

    await _service.Update(entity);
    return Results.Accepted("",new { Mensaje = "Datos actualizados" });
});

app.MapDelete("/Empleados/{id}", async (int id, IEmpleadoService _service, IMapper _mapper) => {
    var entity = await _service.GetById( id);
    await _service.Delete(entity);

    return Results.Accepted("", new { Mensaje = "Datos borrados" });
});

app.UseCors("Nueva politica");
app.Run();
