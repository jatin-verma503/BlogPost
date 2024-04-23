using BlogPostApp.Data;
using BlogPostApp.Repository;
using BlogPostApp.Repository.IRepository;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Add logs to application  Consoe and file 
var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console().WriteTo.File(
    "logs/logs.txt", rollingInterval: RollingInterval.Day
    ).CreateLogger();

Log.Logger = logger;

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddDbContext<BlogPostAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddControllers();
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
