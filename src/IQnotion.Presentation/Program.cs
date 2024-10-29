using IQnotion.Infrastructure;
using IQnotion.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureIQnotionDbContext(builder.Configuration);
builder.Services.ConfigureIQnotionApplicationCore();

builder.Services.ConfigureIQnotionJWTAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddControllers(); 

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IQnotionDbSeed>();
    await seeder.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
