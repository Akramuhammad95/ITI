using API.Middlewares;
using BusinessLogicLayer;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Controllers
// ======================
builder.Services.AddControllers();

// ======================
// Swagger
// ======================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ======================
// CLEAN ARCH DI
// ======================

// 🔹 Application layer (Services)
builder.Services.AddApplication();

// 🔹 Infrastructure layer (Repositories + Dapper)
builder.Services.AddInfrastructure();

var app = builder.Build();

// ======================
// Middleware
// ======================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();