using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfReceipt.Services;

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

        [HttpPost]
        [Route("generatePdf")]
        public IActionResult GeneratePdf([FromBody] string htmlContent)
        {
            byte[] pdfBytes = _pdfService.GeneratePdf(htmlContent);
            return File(pdfBytes, "application/pdf", "receipt.pdf");
        }
    }
}
