using UseCaseStudyBE;
using MediatR;
using UseCaseStudyBE.Helpers;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<NEDbContext>(
    ServiceLifetime.Scoped);
builder.Services.AddScoped<WeatherHelper>();

builder.Services.AddMediatR(typeof(NEDbContext).Assembly);
builder.Services.AddMediatR(typeof(WeatherHelper).Assembly);

builder.Services.AddMemoryCache();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();