using Leapy.Logic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "BookDetails",
    pattern: "{controller=Books}/{action=BookDetails}/{UPC?}");

app.MapControllerRoute(
    name: "PhoneDetails",
    pattern: "{controller=Phone}/{action=PhoneDetails}/{ArtNr?}");

app.MapControllerRoute(
    name: "AddFavoriteBook",
    pattern: "Favorite/AddFavoriteBook/{UPC?}",
    defaults: new { controller = "Favorite", action = "AddFavoriteBook" });

app.MapControllerRoute(
    name: "AddFavoritePhone",
    pattern: "Favorite/AddFavoritePhone/{ArtNr?}",
    defaults: new { controller = "Favorite", action = "AddFavoritePhone" });

app.Run();

