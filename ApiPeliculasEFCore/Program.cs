using ApiPeliculasEFCore;
using ApiPeliculasEFCore.CompiledModels;
using ApiPeliculasEFCore.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDBContext>(opciones => {

         opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x=>x.UseNetTopologySuite());
         opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
         //opciones.UseModel(ApplicationDBContextModel.Instance);
}
);

//builder.Services.AddDbContext<ApplicationDBContext>();

builder.Services.AddScoped<IActualizadorObservableCollection, ActualizadorObservableCollection>();

builder.Services.AddScoped<IservicioUsuario, ServicioUsuario>();
builder.Services.AddScoped<IEventosDbContext, EventosDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    applicationDbContext.Database.Migrate();
}*/

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
