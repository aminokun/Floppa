using Leapy.Data.Repositories;
using Leapy.Logic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<UserService>();
builder.Services.AddScoped<UserDataAccess>();
builder.Services.AddTransient<FavoriteService>();
builder.Services.AddTransient<PhoneService>();
builder.Services.AddTransient<BookService>();




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

app.UseAuthentication(); // Add this line to enable authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "Details",
    pattern: "{controller=Phone}/{action=Details}/{ArtNr?}");

app.MapControllerRoute(
    name: "AddPhoneToFavorites",
    pattern: "Favorite/AddPhoneToFavorites/{ArtNr?}",
    defaults: new { controller = "Favorite", action = "AddPhoneToFavorites" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

