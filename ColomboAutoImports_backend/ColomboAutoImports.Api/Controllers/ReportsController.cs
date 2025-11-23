using ClosedXML.Excel;
using ColomboAutoImports.Core.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ColomboAutoImports.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        [HttpPost("generate-excel")]
        public IActionResult GetExcel([FromBody] VehicleDetails vehicleDetails)
        {
            vehicleDetails.Date = DateTime.UtcNow.Date.ToString();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Vehicle Import Cost Quote");

                var properties = typeof(VehicleDetails).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                for (int i = 0; i < properties.Length; i++)
                {
                    var prop = properties[i];
                    var value = prop.GetValue(vehicleDetails)?.ToString() ?? "";
                    worksheet.Cell(i + 1, 1).Value = prop.Name;
                    worksheet.Cell(i + 1, 2).Value = value;
                    worksheet.Cell(i + 1, 1).Style.Font.Bold = true;
                }

                worksheet.Columns().AdjustToContents();

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Position = 0;

                    var fileName = $"VehicleImportQuote_{System.DateTime.Now:yyyyMMddHHmmss}.xlsx";

                    return File(
                        stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName
                    );
                }
            }
        }

        [HttpPost("generate-pdf")]
        public IActionResult GeneratePdf([FromBody] VehicleDetails vehicleDetails)
        {
            var stream = new MemoryStream();

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            writer.CloseStream = false;

            document.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Paragraph title = new Paragraph("Vehicle Import Cost Quote", titleFont)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20
            };
            document.Add(title);

            var bodyFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

            document.Add(new Paragraph($"Date: {DateTime.UtcNow.Date.ToString()}"));
            document.Add(new Paragraph($"Customer Name: {vehicleDetails.Customer}"));
            document.Add(new Paragraph($"Brand: {vehicleDetails.Brand}"));
            document.Add(new Paragraph($"Model: {vehicleDetails.Model}"));
            document.Add(new Paragraph($"SubModel: {vehicleDetails.SubModel}"));
            document.Add(new Paragraph($"Year: {vehicleDetails.Year}"));
            document.Add(new Paragraph($"Color: {vehicleDetails.Color}"));
            document.Add(new Paragraph($"Fuel Type: {vehicleDetails.FuelType}"));
            document.Add(new Paragraph($"Engine Capacity: {vehicleDetails.EngineCapacity}"));
            document.Add(new Paragraph($"Chasis ID: {vehicleDetails.ChassisId}"));
            document.Add(new Paragraph($"CIF JPY: {vehicleDetails.CIFJPY}"));
            document.Add(new Paragraph($"Exchange Rate: {vehicleDetails.ExchangeRate}"));
            document.Add(new Paragraph($"CIF LKR: {vehicleDetails.CIFLKR}"));
            document.Add(new Paragraph($"Total Duty: {vehicleDetails.TotalDuty}"));
            document.Add(new Paragraph($"Clearing Cahrges: {vehicleDetails.ClearingCharges}"));
            document.Add(new Paragraph($"Delivery Charges: {vehicleDetails.DeliveryCharges}"));
            document.Add(new Paragraph($"Total Cost: {vehicleDetails.TotalCost}"));
            document.Close();

            stream.Position = 0;

            string fileName = $"VehicleImportQuote_{System.DateTime.Now:yyyyMMddHHmmss}.pdf";

            return File(stream.ToArray(), "application/pdf", fileName);
        }
    }
}
