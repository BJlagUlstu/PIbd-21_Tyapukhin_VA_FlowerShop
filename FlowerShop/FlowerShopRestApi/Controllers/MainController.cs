using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FlowerShopBusinessLogic.BusinessLogics;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopBusinessLogic.BindingModels;

namespace FlowerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly FlowerLogic _flower;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, FlowerLogic flower, OrderLogic main)
        {
            _order = order;
            _flower = flower;
            _main = main;
        }
        [HttpGet]
        public List<FlowerViewModel> GetFlowerList() => _flower.Read(null)?.ToList();
        [HttpGet]
        public FlowerViewModel GetFlower(int flowerID) => _flower.Read(new FlowerBindingModel { Id = flowerID })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}