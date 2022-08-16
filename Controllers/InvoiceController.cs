using DinkToPdf;
using DinkToPdf.Contracts;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.DotNet.ProjectModel;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using TestHotel.DTOs;
using TestHotel.Entities;
using TestHotel.Service.IService;
using static TestHotel.Service.InvoiceService;

namespace TestHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private IConverter _converter;

        public InvoiceController(IInvoiceService invoiceService, IConverter converter)
        {
            _invoiceService = invoiceService;
            _converter = converter; ;
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<Invoice> GetAll()
        {
            var result = _invoiceService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Int64> Create(InvoiceDTO model)
        {
            if (model == null) return 0;
            var result = await _invoiceService.Create(model);
            return result;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<Int64> Update(InvoiceDTO model)
        {
            if (model == null) return 0;
            var result = await _invoiceService.Update(model);
            return result;
        }

        [HttpPost]
        [Route("delete")]

        public async Task Delete(int id)
        {
            await _invoiceService.Delete(id);
        }


        [HttpPost]
        [Route("GetById")]
        public async Task<Invoice> GetById(int id)
        {
            var result = await _invoiceService.GetById(id);
            return result;
        }


        [HttpPost]
        [Route("printInvoice")]
        public IActionResult CreatePDF(PrintInvoiceDTO datas)
        {


            var globalSettings = new DinkToPdf.GlobalSettings
            {
                ColorMode = DinkToPdf.ColorMode.Color,
                Orientation = DinkToPdf.Orientation.Portrait,
                PaperSize = DinkToPdf.PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = @"D:\PDFCreator\Invoice.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(datas),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return Ok("Successfully created PDF document.");


        }
    }
}
