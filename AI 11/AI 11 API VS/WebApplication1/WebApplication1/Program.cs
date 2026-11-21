var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Required for Minimal APIs
builder.Services.AddSwaggerGen();           // Registers the Swagger generator



var aiBasedUrl = builder.Configuration["AI_BASE"] ?? "http://localhost:8000";


builder.Services.AddHttpClient("ai", client => { client.BaseAddress = new Uri(aiBasedUrl); } );

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
