using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using iTextSharp.text;
using System.Reflection.Metadata;
using MHBusinessLayer.Abstract;
using MHDataAccessLayer.Concrete;
using System.Linq;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfReportController : ControllerBase
    {
        private IPdfService _pdfService;
        private Context _c;
        public PdfReportController(IPdfService pdfService, Context c)
        {
            _pdfService = pdfService;
            _c = c;
        }



        //[HttpGet("DynamicPdfReport")]
        //public IActionResult DynamicPdfReport()
        //{
        //    var staffList = _c.Staffs.ToList(); // Staff verilerini al

        //    using (var stream = new MemoryStream())
        //    {
        //        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
        //        PdfWriter.GetInstance(document, stream);

        //        document.Open();

        //        foreach (var staff in staffList)
        //        {
        //            Paragraph paragraph = new Paragraph($"Ad: {staff.Name}, Soyad: {staff.Title}, Pozisyon: {staff.SocialMedia1}");
        //            document.Add(paragraph);
        //        }

        //        document.Close();

        //        stream.Position = 0;

        //        var fileStreamResult = new FileStreamResult(stream, "application/pdf")
        //        {
        //            FileDownloadName = "staff_report.pdf"
        //        };

        //        return fileStreamResult;
        //    }
        //}


        [HttpGet("StaticPdfReport")]

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "pdff/pdfreports/" + "dosya1.pdf");
            using (var stream = new FileStream(path, FileMode.Create))
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4); // format ne olsun ?
                PdfWriter.GetInstance(document, stream);

                document.Open();

                Paragraph paragraph = new Paragraph("Personel Listesi");

                document.Add(paragraph);
                document.Close();


            }
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(fileStream, "application/pdf");



            //    return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }
        [HttpGet("StaticCustomerReport")]

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "pdf/" + "dosya4.pdf");
            var stream = new FileStream(path, FileMode.Create);

            iTextSharp.text.Document document = new iTextSharp.text.Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3); // parantez içerisindeki sayı kaç sütun olacağını söyler

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Eylül");
            pdfPTable.AddCell("Yücedağ");
            pdfPTable.AddCell("11111111110");

            pdfPTable.AddCell("Kemal");
            pdfPTable.AddCell("Yıldırım");
            pdfPTable.AddCell("22222222222");

            pdfPTable.AddCell("Mehmet");
            pdfPTable.AddCell("Yücedağ");
            pdfPTable.AddCell("44444444445");

            document.Add(pdfPTable);

            document.Close();
            return File("/pdf/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
