using HayvanBarinagi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add database connection
builder.Services.AddDbContext<HayvanBarinagiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity service
builder.Services.AddIdentity<Kullanici, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<HayvanBarinagiContext>()
    .AddDefaultTokenProviders();

// Add cookie authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie();

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("Kullanıcı"));
});

// For session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add MVC service
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Add error handling, HTTPs and other middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Ensure the creation of roles and admin user
var serviceProvider = app.Services.CreateScope().ServiceProvider;
await CreateRolesAndAdminUser(serviceProvider);

app.Run();

static async Task CreateRolesAndAdminUser(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<Kullanici>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "Kullanıcı" };
    foreach (var roleName in roles)
    {
        if (!(await roleManager.RoleExistsAsync(roleName)))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    string adminEmail = "s221210017@sakarya.edu.tr";
    string adminPassword = "123Sau321/";

    var user = await userManager.FindByEmailAsync(adminEmail);
    if (user == null)
    {
        user = new Kullanici
        {
            UserName = adminEmail,
            Email = adminEmail,
            Ad = "Admin",
            Soyad = "Admin",
            DogumTarihi = DateTime.Now,
            TelefonNumarasi = "5555555555",
            Adres = "Admin"
        };
        var result = await userManager.CreateAsync(user, adminPassword);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
            return;
        }
        await userManager.AddToRoleAsync(user, roles[0]);
    }
}

