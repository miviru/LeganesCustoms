using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Microsoft.JSInterop;
using LeganesCustomsBlazor.Dtos;

public class PdfService
{
    private readonly IJSRuntime _jsRuntime;

    public PdfService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task GenerateAndDownloadPdf(FacturaDto factura)
    {
        Console.WriteLine($"Generando PDF para la factura: {factura.Id}");

        if (factura == null)
        {
            throw new ArgumentNullException(nameof(factura), "La factura no puede ser nula.");
        }

        // Genera el PDF
        var pdfData = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(595, 842); // Tamaño A4
                page.Margin(2, Unit.Centimetre);
                page.Header().Text($"Factura {factura.Id}").FontSize(20).Bold().AlignCenter();

                page.Content().Column(column =>
                {
                    if (factura.Cita != null)
                    {
                        column.Item().Text("Cita Relacionada").FontSize(16).Bold();
                        column.Item().Text($"Fecha: {factura.Cita.Fecha.ToShortDateString()}");
                        column.Item().Text($"Hora: {factura.Cita.Hora}");
                    }

                    column.Item().Text("Información del Cliente").FontSize(16).Bold();
                    column.Item().Text($"Nombre: {factura.ClienteNombre}");
                    column.Item().Text($"DNI: {factura.DNI}");
                    column.Item().Text($"Dirección: {factura.Direccion}");

                    if (factura.Vehiculo != null)
                    {
                        column.Item().Text("Información del Vehículo").FontSize(16).Bold();
                        column.Item().Text($"Fabricante: {factura.Vehiculo.Fabricante}");
                        column.Item().Text($"Modelo: {factura.Vehiculo.Modelo}");
                        column.Item().Text($"Matrícula: {factura.Vehiculo.Matricula}");
                    }

                    column.Item().Text("Información de la Factura").FontSize(16).Bold();
                    column.Item().Text($"Precio: {factura.Precio} €");
                    column.Item().Text($"Descuento: {factura.Descuento} €");
                    column.Item().Text($"Total: {factura.Total} €");
                });

                page.Footer().AlignCenter().Text("Gracias por su preferencia").FontSize(10);
            });
        }).GeneratePdf();

        // Descarga el PDF
        var fileName = $"Factura_{factura.Id}.pdf";
        await _jsRuntime.InvokeVoidAsync("saveAsFile", fileName, Convert.ToBase64String(pdfData));
    }
}
