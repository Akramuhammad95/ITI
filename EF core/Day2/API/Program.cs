using Application.Interfaces;
using Application.Services;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// Application Services
builder.Services.AddScoped<IStudentService, StudentService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();