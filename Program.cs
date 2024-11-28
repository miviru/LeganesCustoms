using Syncfusion.Blazor;
using Microsoft.EntityFrameworkCore;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Services;
using LeganesCustomsBlazor.Handlers;
using Microsoft.AspNetCore.Antiforgery;


Console.WriteLine("Iniciando configuración en Program.cs...");

var builder = WebApplication.CreateBuilder(args);

// Configurar logging detallado
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options => options.DetailedErrors = true);

builder.Services.AddSyncfusionBlazor();

builder.Services.AddSignalR(options =>
{
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión 'DefaultConnection' no está configurada.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<ClienteService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5183/");
}).AddHttpMessageHandler(sp =>
{
    var antiforgery = sp.GetRequiredService<Microsoft.AspNetCore.Antiforgery.IAntiforgery>();
    var contextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

    return new AntiforgeryHandler(antiforgery, contextAccessor);
});

builder.Services.AddHttpClient<EmpleadoService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5183/");
}).AddHttpMessageHandler(sp =>
{
    var antiforgery = sp.GetRequiredService<IAntiforgery>();
    var contextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

    return new AntiforgeryHandler(antiforgery, contextAccessor);
});


builder.Services.AddAntiforgery(); 
builder.Services.AddHttpContextAccessor();


// Registrar servicios de Cliente
builder.Services.AddScoped<ClienteService>();

// Registrar servicios de Empleado
builder.Services.AddScoped<EmpleadoService>();

// Registrar servicios de Vehiculo
builder.Services.AddScoped<VehiculoService>();

// Registrar servicios de Cita
builder.Services.AddScoped<CitaService>();

// Registrar servicios de Factura
builder.Services.AddScoped<FacturaService>();

// Registrar servicios de Pdf
builder.Services.AddScoped<PdfService>();

var app = builder.Build();

// Llamar a SeedData
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DataInitializer.SeedData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Habilitar página de excepciones para desarrollo
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Configuración del pipeline
app.UseStaticFiles();
app.UseRouting();

// Middleware de antiforgery: debe ir entre UseRouting y los mapeos
app.UseAntiforgery();

app.MapBlazorHub(); // Configura Blazor Server para manejar WebSockets
app.MapControllers(); // Configura los controladores para la API

app.MapRazorComponents<LeganesCustomsBlazor.Components.App>()
    .AddInteractiveServerRenderMode();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Request Path: {context.Request.Path}, Method: {context.Request.Method}");
    try
    {
        await next();
    }
    catch (InvalidOperationException ex) when (ex.Message.Contains("anti-forgery metadata"))
    {
        Console.WriteLine($"Antiforgery Exception at: {context.Request.Path}");
        throw;
    }
});

app.Run();
