using PdfReceipt.Model;
using SelectPdf;

namespace PdfReceipt.Services
{
    public class PdfService
    {
        public byte[] GeneratePdf(HtmlRequest htmlRequest)
        {

            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Landscape;

            PdfDocument document = converter.ConvertHtmlString(htmlRequest.HtmlContent);
            byte[] pdfBytes = document.Save();
            document.Close();

            return pdfBytes;
        }
    }
}
