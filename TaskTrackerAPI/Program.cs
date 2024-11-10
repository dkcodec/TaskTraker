using Microsoft.EntityFrameworkCore;
using TaskTrackerAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Настройка строки подключения к базе данных
builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));

// Настройка CORS для разрешения всех источников, методов и заголовков
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5003") // Замените на ваш URL
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Добавление контроллеров
builder.Services.AddControllers();

// Настройка Swagger (для тестирования API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Применение политики CORS ДО маршрутизации и других middleware
app.UseCors("AllowFrontend");

// Настройка Swagger в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Применение HTTPS редиректа (опционально, отключите для отладки)
// app.UseHttpsRedirection();

app.UseAuthorization();

// Маршрутизация запросов к контроллерам
app.MapControllers();

app.Run();
