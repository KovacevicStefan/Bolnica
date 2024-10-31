using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using arhitektura_projekat.Data;
using Microsoft.AspNetCore.Identity;
using arhitektura_projekat.Models;
using System.Security.Claims;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

// Ove dve linije su bitne za Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Ne dodaj AddAuthentication() jer to već radi AddIdentity
// builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Home/Index";
    options.AccessDeniedPath = "/Home/Index";
    options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    {
        OnRedirectToLogin = context =>
        {
            context.Response.Redirect("/Home/Index?message=auth_required");
            return Task.CompletedTask;
        }
    };
});


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapGet("users/me", async (ClaimsPrincipal claims, ApplicationDbContext context) =>
{
    string UserId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    return await context.Users.FindAsync(UserId);
}).RequireAuthorization();

//app.UseHttpsRedirection();
app.UseStaticFiles();

// Kreiraj uloge prilikom pokretanja aplikacije
using (var scope = app.Services.CreateScope()) // Stvaramo novi opseg
{
    var services = scope.ServiceProvider;
    await CreateRoles(services); // Koristimo servis iz novog opsega
}

app.Run();

// Ova metoda može biti izvan Main metode, ali u istom kontekstu
static async Task CreateRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
    string[] roleNames = { "Admin", "User" };

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            // Kreiraj novu ulogu
            await roleManager.CreateAsync(new Role(roleName));
        }
    }
}
