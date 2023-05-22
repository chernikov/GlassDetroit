using GlassDetroitMVC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var developer = Environment.GetEnvironmentVariable("Developer");

var connectionString = builder.Configuration["ConnectionString:"+ developer +"Connection"];
Console.WriteLine(connectionString);

// Add services to the container.
builder.Services.AddDbContext<GlassDetroitContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();


var app = builder.Build();
var name = app.Environment.EnvironmentName;
Console.WriteLine(name);


// Configure the HTTP request pipeline.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
