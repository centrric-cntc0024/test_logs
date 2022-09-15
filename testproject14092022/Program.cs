using Serilog;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//log configuration for appsettings.json
Log.Logger = new LoggerConfiguration()
    
    .ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    .CreateLogger();





//global log-------->

//var _logger=new LoggerConfiguration()
//    //.MinimumLevel.Error()
//    .WriteTo.File("C:\\Users\\Centrric\\Desktop\\lo\\api.log", rollingInterval: RollingInterval.Day)
//    .CreateLogger();
//builder.Logging.AddSerilog(_logger);


//custom log---------->

//Log.Logger = new LoggerConfiguration().WriteTo.File("C:\\Users\\Centrric\\Desktop\\lo\\api.log", rollingInterval: RollingInterval.Day).CreateLogger();

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
