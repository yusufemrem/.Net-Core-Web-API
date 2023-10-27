using HotelProjectApi.Models;
using MHBusinessLayer.Abstract;
using MHDataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }
        [HttpGet("StaffList")]

        public List<StaffModel> StaffList()
        {
            List<StaffModel> staffModels = new List<StaffModel>();
            using (var c = new Context())
            {
                staffModels = c.Staffs.Select(x => new StaffModel
                {
                    Name = x.Name,
                    Title = x.Title,
                    SocialMedia1 = x.SocialMedia1,
                }).ToList();
            }
            return staffModels;
        }
        [HttpGet("StaticExcelReport")]
        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList(StaffList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        }
        [HttpGet("StaffExcelReport")]

        public IActionResult StaffExcelReport()
        {
            using (var workBook = new ClosedXML.Excel.XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Kadro Listesi");
                workSheet.Cell(1, 1).Value = "İsim";
                workSheet.Cell(1, 2).Value = "Title";
                workSheet.Cell(1, 3).Value = "SocialMedia";

                int rowCount = 2;
                foreach (var item in StaffList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Name;
                    workSheet.Cell(rowCount, 2).Value = item.Title;
                    workSheet.Cell(rowCount, 3).Value = item.SocialMedia1;
         
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
        }
    }
}
