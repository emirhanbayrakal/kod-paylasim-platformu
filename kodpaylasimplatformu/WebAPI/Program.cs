using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// CORS ayarlarını ekleyin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()  // Herhangi bir kaynağa izin ver
               .AllowAnyMethod()  // Herhangi bir HTTP metoduna izin ver (GET, POST, vb.)
               .AllowAnyHeader(); // Herhangi bir başlığa izin ver
    });
});



builder.Services.AddScoped<UserDbContext>();
// Swagger'ı yapılandırma
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Swagger UI'yi kullanma
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS'u kullanma
app.UseCors("AllowAll"); // CORS politikasını uygulama

app.UseHttpsRedirection();

// API Controller'ları haritalama
app.MapControllers();

app.Run();
