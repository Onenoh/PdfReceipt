using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PdfReceipt.Model;
using PdfReceipt.Services;
using System.Web;

namespace PdfReceipt.Controllers
{
    [Route("api/pdf")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly PdfService _pdfService;
        public PdfController(PdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet]
        [Route("generatePdf")]
        public IActionResult GeneratePdf([FromBody] HtmlRequest htmlContent)
        {
            
            byte[] pdfBytes = _pdfService.GeneratePdf(htmlContent);
            return File(pdfBytes, "application/pdf", "receipt.pdf");
        }
    }
}
