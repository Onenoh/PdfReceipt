using SelectPdf;

namespace PdfReceipt.Services
{
    public class PdfService
    {
        public byte[] GeneratePdf(string htmlContent)
        {
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument document = converter.ConvertHtmlString(htmlContent);
            byte[] pdfBytes = document.Save();
            document.Close();
            return pdfBytes;
        }
    }
}
