using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using ZooManagement;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
    });
});

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); //To present Enums as Strings
    });

builder.Services.AddDbContext<Zoo>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ZooApiDatabaseProd"));
    // options.UseNpgsql(
    //     "Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;Include Error Detail=True;"
    // );
    options.EnableSensitiveDataLogging();
});

// if (Environment.GetEnvironmentVariable("ASPNETWEBAPI_ENVIRONMENT") == "Production")
// {
//     builder.Services.AddDbContext<Zoo>(options =>
//     {
//         options.UseSqlite(builder.Configuration.GetConnectionString("ZooApiDatabaseProd"));
//     });
// }
// else
// {
//     builder.Services.AddDbContext<Zoo>(options =>
//     {
//         options.UseSqlite(builder.Configuration.GetConnectionString("ZooApiDatabase"));
//         // options.UseNpgsql(
//         //     "Host=localhost; Port=5432; Database=zoo; Username=zoo; Password=zoo;Include Error Detail=True;"
//         // );
//         options.EnableSensitiveDataLogging();
//     });
// }
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddNLog();
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
    if (app.Environment.IsDevelopment())
        options.RoutePrefix = "swagger";
    else
        options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();
