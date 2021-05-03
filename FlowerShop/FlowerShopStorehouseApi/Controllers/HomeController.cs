using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopBusinessLogic.BindingModels;
using FlowerShopStorehouseApi.Models;

namespace FlowerShopStorehouseApi.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIEmployer.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouses"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password != Program.Password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.Enter = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(string storehouseName, string FIO)
        {
            if (!string.IsNullOrEmpty(storehouseName) && !string.IsNullOrEmpty(FIO))
            {
                APIEmployer.PostRequest("api/storehouse/CreateOrUpdateStorehouse", new StorehouseBindingModel
                {
                    FullName = FIO,
                    StorehouseName = storehouseName,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = new Dictionary<int, (string, int)>()
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите имя и ответственного");
        }

        [HttpGet]
        public IActionResult Update(int storehouseId)
        {
            var storehouse = APIEmployer.GetRequest<StorehouseViewModel>($"api/storehouse/GetStorehouse?storehouseId={storehouseId}");
            ViewBag.StoreComponents = storehouse.StorehouseComponents.Values;
            ViewBag.StorehouseName = storehouse.StorehouseName;
            ViewBag.FIO = storehouse.FullName;
            return View();
        }

        [HttpPost]
        public void Update(int storehouseId, string storehouseName, string FIO)
        {
            if (!string.IsNullOrEmpty(storehouseName) && !string.IsNullOrEmpty(FIO))
            {
                var storehouse = APIEmployer.GetRequest<StorehouseViewModel>($"api/storehouse/GetStorehouse?storehouseId={storehouseId}");
                if (storehouse == null)
                {
                    return;
                }
                APIEmployer.PostRequest("api/storehouse/CreateOrUpdateStorehouse", new StorehouseBindingModel
                {
                    FullName = FIO,
                    StorehouseName = storehouseName,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = storehouse.StorehouseComponents,
                    StorehouseId = storehouse.StorehouseId
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Storehouse = APIEmployer.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouses");
            return View();
        }

        [HttpPost]
        public void Delete(int storehouseId)
        {
            APIEmployer.PostRequest("api/storehouse/DeleteStorehouse", new StorehouseBindingModel
            {
                StorehouseId = storehouseId
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddComponent()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Storehouse = APIEmployer.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouses");
            ViewBag.Component = APIEmployer.GetRequest<List<ComponentViewModel>>("api/storehouse/GetComponents");
            return View();
        }

        [HttpPost]
        public void AddComponent(int storehouseId, int componentId, int count)
        {
            APIEmployer.PostRequest("api/storehouse/AddComponent", new AddComponentBindingModel
            {
                StorehouseId = storehouseId,
                ComponentId = componentId,
                Count = count
            });
            Response.Redirect("Index");
        }
    }
}