var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Required for Minimal APIs
builder.Services.AddSwaggerGen();           // Registers the Swagger generator

var app = builder.Build();

// Enable Swagger middleware in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   // Serves the generated OpenAPI JSON
    app.UseSwaggerUI(); // Serves the interactive web UI
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
