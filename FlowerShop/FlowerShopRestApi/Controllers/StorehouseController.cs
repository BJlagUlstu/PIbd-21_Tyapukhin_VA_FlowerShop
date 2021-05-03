using Microsoft.AspNetCore.Mvc;
using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopBusinessLogic.BindingModels;
using System.Collections.Generic;
using System.Linq;

namespace FlowerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorehouseController : ControllerBase
    {
        private readonly StorehouseLogic _storehouse;
        private readonly ComponentLogic _component;
        public StorehouseController(StorehouseLogic storehouse, ComponentLogic component)
        {
            _storehouse = storehouse;
            _component = component;
        }
        [HttpGet]
        public List<StorehouseViewModel> GetStorehouses() => _storehouse.Read(null)?.ToList();
        [HttpGet]
        public StorehouseViewModel GetStorehouse(int storehouseId) => _storehouse.Read(new StorehouseBindingModel { StorehouseId = storehouseId })?[0];
        [HttpPost]
        public void CreateOrUpdateStorehouse(StorehouseBindingModel model) => _storehouse.CreateOrUpdate(model);
        [HttpPost]
        public void DeleteStorehouse(StorehouseBindingModel model) => _storehouse.Delete(model);
        [HttpPost]
        public void AddComponent(AddComponentBindingModel model) => _storehouse.AddComponent(model);
        [HttpGet]
        public List<ComponentViewModel> GetComponents() => _component.Read(null);
    }
}