using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.UI.Services;
using Syncfusion.Blazor;
using Blazored.LocalStorage; // Importar Blazored.LocalStorage
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

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

// Agregar soporte para Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Configurar Base de Datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Configurar Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true; // Requerir confirmación de cuenta
    options.User.RequireUniqueEmail = true;       // Requerir email único
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Configurar Autenticación y Autorización
builder.Services.AddAuthentication("Identity.Application")
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true; // Evitar acceso desde JavaScript
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Usar Always en producción
        options.Cookie.SameSite = SameSiteMode.Lax; // Asegurar compatibilidad
        options.LoginPath = "/Identity/Account/Login"; // Ruta para login
        options.LogoutPath = "/Identity/Account/Logout"; // Ruta para logout
        options.AccessDeniedPath = "/Identity/Account/AccessDenied"; // Redirección si acceso denegado
        options.SlidingExpiration = true; // Extender expiración en actividad
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Tiempo de expiración de cookie
    });

builder.Services.AddAuthorization();

// Configurar HttpClient con BaseAddress
builder.Services.AddHttpClient("DefaultClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"] ?? "http://localhost:5183/");
});

// Servicios adicionales
builder.Services.AddSingleton<IEmailSender>(new SendGridEmailSender("your-sendgrid-api-key"));
builder.Services.AddHttpContextAccessor(); // Permitir acceso al HttpContext en cualquier servicio
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<VehiculoService>();
builder.Services.AddScoped<CitaService>();
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

    // Migrar la base de datos
    context.Database.Migrate();

    // Crear roles si no existen
    string[] roleNames = { "Admin", "Cliente", "EmpleadoMecanico", "EmpleadoRecepcionista" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Crear usuario Admin si no existe
    var adminEmail = "admin@example.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
        var result = await userManager.CreateAsync(adminUser, "Admin123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

    // Crear usuario Cliente si no existe
    var clienteEmail = "cliente@example.com";
    var clienteUser = await userManager.FindByEmailAsync(clienteEmail);
    if (clienteUser == null)
    {
        clienteUser = new IdentityUser { UserName = clienteEmail, Email = clienteEmail };
        var result = await userManager.CreateAsync(clienteUser, "Cliente123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(clienteUser, "Cliente");
        }
    }

    // Crear usuario EmpleadoMecanico si no existe
    var mecanicoEmail = "mecanico@example.com";
    var mecanicoUser = await userManager.FindByEmailAsync(mecanicoEmail);
    if (mecanicoUser == null)
    {
        mecanicoUser = new IdentityUser { UserName = mecanicoEmail, Email = mecanicoEmail };
        var result = await userManager.CreateAsync(mecanicoUser, "Mecanico123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(mecanicoUser, "EmpleadoMecanico");
        }
    }

    // Crear usuario EmpleadoRecepcionista si no existe
    var recepcionistaEmail = "recepcionista@example.com";
    var recepcionistaUser = await userManager.FindByEmailAsync(recepcionistaEmail);
    if (recepcionistaUser == null)
    {
        recepcionistaUser = new IdentityUser { UserName = recepcionistaEmail, Email = recepcionistaEmail };
        var result = await userManager.CreateAsync(recepcionistaUser, "Recepcionista123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(recepcionistaUser, "EmpleadoRecepcionista");
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
