using FlowerShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.HelperModels
{
    public class PdfInfoOrdersAllDates
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportOrdersAllDatesViewModel> Orders { get; set; }
    }
}