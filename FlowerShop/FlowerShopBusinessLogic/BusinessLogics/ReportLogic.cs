using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.HelperModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IFlowerStorage _flowerStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStorehouseStorage _storehouseStorage;
        public ReportLogic(IFlowerStorage flowerStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IStorehouseStorage storehouseStorage)
        {
            _flowerStorage = flowerStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _storehouseStorage = storehouseStorage;
        }
        // Получение списка компонент с указанием, в каких растениях используются
        public List<ReportFlowerComponentViewModel> GetFlowerComponent()
        {
            var components = _componentStorage.GetFullList();
            var flowers = _flowerStorage.GetFullList();
            var list = new List<ReportFlowerComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportFlowerComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Flowers = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var flower in flowers)
                {
                    if (flower.FlowerComponents.ContainsKey(component.Id))
                    {
                        record.Flowers.Add(new Tuple<string, int>(flower.FlowerName, flower.FlowerComponents[component.Id].Item2));
                        record.TotalCount += flower.FlowerComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders()
        {
            return _orderStorage.GetFullList().GroupBy(x => x.DateCreate.Date)
            .Select(g => new ReportOrdersViewModel
            {
                DateCreate = g.FirstOrDefault().DateCreate,
                Count = g.Count(),
                Sum = g.Sum(s => s.Sum)
            })
           .ToList();
        }
        // Получение списка складов с указанием используемых компонентов
        public List<ReportStorehouseComponentViewModel> GetComponentsStorehouse()
        {
            var components = _componentStorage.GetFullList();
            var storehouses = _storehouseStorage.GetFullList();
            var list = new List<ReportStorehouseComponentViewModel>();
            foreach (var storehouse in storehouses)
            {
                var record = new ReportStorehouseComponentViewModel
                {
                    StorehouseName = storehouse.StorehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (storehouse.StorehouseComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName, storehouse.StorehouseComponents[component.Id].Item2));
                        record.TotalCount += storehouse.StorehouseComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        // Сохранение складов в файл-Word
        public void SaveStorehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Storehouses = _storehouseStorage.GetFullList()
            });
        }
        // Сохранение склада с указанием компонент в файл-Excel
        public void SaveComponentStorehouseToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                ComponentsStorehouse = GetComponentsStorehouse()
            });
        }
        // Сохранение заказов в файл-Pdf
        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders()
            });
        }
    }
}