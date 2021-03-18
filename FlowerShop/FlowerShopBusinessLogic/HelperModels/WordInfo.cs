using FlowerShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ComponentViewModel> Components { get; set; }
        public List<FlowerViewModel> Flowers { get; set; }
    }
}