using FiGroup_WebApi.Aplicacion.Comandos;
using FiGroup_WebApi.Aplicacion.Commands;
using FiGroup_WebApi.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(GetTasksCommand));

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(DeleteTaskCommand).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetTasksCommand).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(UpdateTaskCommand).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(GetTasksByStatusCommand).Assembly));
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(CreateTaskCommand).Assembly));
builder.Services.AddDbContext<FiGroupContext>(
opts => opts.UseSqlServer(
                builder.Configuration.GetConnectionString("ConexionDatabase"),
                options => options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)
            )
    );

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader();
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

app.UseAuthorization();

app.UseCors("AllowReactApp");

app.MapControllers();

app.Run();
