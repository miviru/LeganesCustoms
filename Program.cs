using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using LeganesCustomsBlazor.Data;
using LeganesCustomsBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Components/Pages"; // Cambiar la raíz de Razor Pages
});
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR(); // Agregar SignalR
builder.Services.AddSyncfusionBlazor();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<VehiculoService>();
builder.Services.AddScoped<CitaService>();
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<PdfService>();

var app = builder.Build();

// Configurar el pipeline
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

// Mapear endpoints
app.MapControllers();
app.MapBlazorHub(); // Blazor Server
app.MapFallbackToPage("/_Host");

app.Run();
