using GestaoDeUbs.Domain.Handlers;
using GestaoDeUbs.Domain.Repository;
using GestodeUbs.Infra.Context;
using GestodeUbs.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Injecao de dependencias - DI
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")
    )
);
builder.Services.AddTransient<IPacienteRepositorio, PacienteRepository>();
builder.Services.AddTransient<IHospitalRepositorio, HospitalRepository>();
builder.Services.AddTransient<IEncaminhamentoRepositorio, EncaminhamentoRepository>();
builder.Services.AddTransient<PacienteHandler, PacienteHandler>();
builder.Services.AddTransient<HospitalHandler, HospitalHandler>();
builder.Services.AddTransient<EncaminhamentoHandler, EncaminhamentoHandler>();
//Injecao de dependencias - DI

// Ciclos Json
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
// Ciclos Json



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


