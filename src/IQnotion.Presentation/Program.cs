using IQnotion.ApplicationCore;
using IQnotion.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IQnotionServices>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureIQnotionDbContext(builder.Configuration);
builder.Services.ConfigureIQnotionCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

IQnotionFileApi.ConfigureRouting(app);
IQnotionNotionApi.ConfigureRouting(app);

app.Run();
