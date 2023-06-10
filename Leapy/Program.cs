using Leapy.Interfaces;
using Leapy.Logic.Services;
using Leapy.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Leapy.Factory;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection

//AddScoped returns zelfde instance van de types voor single client request.
builder.Services.AddScoped<IFavorite, FavoriteDataAccess>();
builder.Services.AddScoped<IUser, UserDataAccess>();
builder.Services.AddScoped<ISmartphone, PhoneDataAccess>();
builder.Services.AddScoped<IBook, BookDataAccess>();

builder.Services.AddScoped<ISmartphoneFactory, PhoneFactory>();
builder.Services.AddScoped<IBookFactory, BookFactory>();


//AddTransient returns nieuwe instance van classes elke request. 
builder.Services.AddTransient<FavoriteService>();
builder.Services.AddTransient<UserService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Details",
    pattern: "{controller=Phone}/{action=Details}/{ArtNr?}");

app.MapControllerRoute(
    name: "AddFavoritePhone",
    pattern: "Favorite/AddFavoritePhone/{ArtNr?}",
    defaults: new { controller = "Favorite", action = "AddFavoritePhone" });

app.MapControllerRoute(
    name: "Details",
    pattern: "{controller=Books}/{action=Details}/{UPC?}");

app.MapControllerRoute(
    name: "AddFavoriteBook",
    pattern: "Favorite/AddFavoriteBook/{UPC?}",
    defaults: new { controller = "Favorite", action = "AddFavoriteBook" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

