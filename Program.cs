using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.UI.Services;
using Syncfusion.Blazor;
using Blazored.LocalStorage;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Services;
using Syncfusion.Licensing;

var builder = WebApplication.CreateBuilder(args);

SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF1cX2hIfEx3Qnxbf1x0ZFFMZV5bR3FPMyBoS35RckRhWH9edHFXRWdUUE13");

// Configurar servicios
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Components/Pages";
});
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredLocalStorage();

// Configurar Base de Datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("DefaultConnection"));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Configurar Autenticación y Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.LoginPath = "/Identity/Account/Login";
        options.LogoutPath = "/Identity/Account/Logout";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

// Configurar redirecciones de cookies para APIs
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        if (context.Request.Path.StartsWithSegments("/api"))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
        else
        {
            context.Response.Redirect(context.RedirectUri);
        }
        return Task.CompletedTask;
    };
});


// Configurar HttpClient
builder.Services.AddHttpClient("DefaultClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"] ?? "http://localhost:5183/");
    client.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue
    {
        NoCache = true,
        NoStore = true,
        MustRevalidate = true
    };
});


// Agregar servicios necesarios
builder.Services.AddSingleton<IEmailSender>(new SendGridEmailSender("your-sendgrid-api-key"));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<VehiculoService>();
builder.Services.AddScoped<ICitasService, CitaService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<PdfService>();
builder.Services.AddSingleton<ReferenciaVehiculosService>();

var app = builder.Build();

// Inicializar datos
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    context.Database.Migrate();

    string[] roleNames = { "Admin", "Cliente", "EmpleadoMecanico", "EmpleadoRecepcionista" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    await CreateDefaultUser(userManager, "admin@example.com", "Admin123!", "Admin");
    await CreateDefaultUser(userManager, "cliente@example.com", "Cliente123!", "Cliente");
    await CreateDefaultUser(userManager, "mecanico@example.com", "Mecanico123!", "EmpleadoMecanico");
    await CreateDefaultUser(userManager, "recepcionista@example.com", "Recepcionista123!", "EmpleadoRecepcionista");
}

async Task CreateDefaultUser(UserManager<IdentityUser> userManager, string email, string password, string role)
{
    var user = await userManager.FindByEmailAsync(email);
    if (user == null)
    {
        user = new IdentityUser { UserName = email, Email = email };
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, role);
        }
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
