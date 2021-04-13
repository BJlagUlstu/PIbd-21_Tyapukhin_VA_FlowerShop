using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class ReportStorehouseComponentViewModel
    {
        public string StorehouseName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}