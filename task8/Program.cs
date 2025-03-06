using Microsoft.EntityFrameworkCore;
using task8.Data;
using task8.Services.Abstract;
using task8.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
string connStr= builder.Configuration.GetConnectionString("MSSQLLibrary")??
    throw new InvalidOperationException("You should specify conn string!");
builder.Services.AddDbContext<LibraryContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(connStr));

//builder.Services.AddSingleton<IFilmRepository, MockFilmRepository>();
builder.Services.AddScoped<IFilmRepository, EFFilmRepository>();
var app = builder.Build();
app.UseDefaultFiles();

app.UseRouting();
app.UseStaticFiles();
app.MapRazorPages();
app.MapGet("/", (context) =>
{
    context.Response.Redirect("/movies");
    return Task.CompletedTask;
});

app.Run();