using FlowerShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportFlowerComponentViewModel> ComponentsFlower { get; set; }
        public List<ReportStorehouseComponentViewModel> ComponentsStorehouse { get; set; }
    }
}