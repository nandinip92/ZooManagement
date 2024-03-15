using System.Text.Json.Serialization;
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

builder.Services.AddControllers().AddJsonOptions(options=>{
    options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<Zoo>(options =>
{
    options.EnableSensitiveDataLogging();
});

builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddNLog();
});

// Add services to the container.
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

app.UseCors();

app.MapControllers();

app.Run();
