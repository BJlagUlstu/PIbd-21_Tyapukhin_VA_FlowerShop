using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.ViewModels
{
    public class ReportFlowerComponentViewModel
    {
        public string ComponentName { get; set; }
        public string FlowerName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Flowers { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}