using Microsoft.EntityFrameworkCore;
using Cars.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarsContext>(options =>
{
    options.UseMySql(
        "server=localhost;database=fz_cars;user=fz_cars;password=asd123",
        MySqlServerVersion.LatestSupportedServerVersion
    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
{
    using var ctx = serviceScope.ServiceProvider.GetService<CarsContext>();
    ctx!.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
