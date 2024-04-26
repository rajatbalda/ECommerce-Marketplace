using AmazonFresh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession(options => options.Cookie.MaxAge = System.TimeSpan.FromDays(21));
builder.Services.AddMemoryCache();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AmazonFreshContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AmazonfreshConnection")));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseAuthorization();
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
