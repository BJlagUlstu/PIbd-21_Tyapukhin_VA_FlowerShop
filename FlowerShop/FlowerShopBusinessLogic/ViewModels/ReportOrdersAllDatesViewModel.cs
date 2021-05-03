using System;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class ReportOrdersAllDatesViewModel
    {
        public DateTime DateCreate { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}