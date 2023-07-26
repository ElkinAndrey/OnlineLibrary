var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер.

builder.Services.AddControllers();
// Узнайте больше о настройке Swagger/OpenAPI на странице https://aka.ms/aspnetcore/swashbuckle.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройте конвейер HTTP-запросов.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
