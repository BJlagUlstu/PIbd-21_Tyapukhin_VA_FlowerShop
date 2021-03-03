using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.Interfaces
{
    public interface IStorehouseStorage
    {
        List<StorehouseViewModel> GetFullList();
        List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model);
        StorehouseViewModel GetElement(StorehouseBindingModel model);
        void Insert(StorehouseBindingModel model);
        void Update(StorehouseBindingModel model);
        void Delete(StorehouseBindingModel model);
    }
}