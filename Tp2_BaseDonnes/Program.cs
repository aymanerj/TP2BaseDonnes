using Microsoft.EntityFrameworkCore;
using Tp2_BaseDonnes.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FootContext>(
    options=> options.UseSqlServer(builder.Configuration.GetConnectionString("BdFoot")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Equipes}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
