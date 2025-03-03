var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IFilmRepository, MockFilmRepository>();
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