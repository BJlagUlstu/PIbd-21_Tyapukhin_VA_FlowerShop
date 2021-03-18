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
        public ReportLogic(IFlowerStorage flowerStorage, IComponentStorage componentStorage, IOrderStorage orderStorage)
        {
            _flowerStorage = flowerStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
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
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                FlowerName = x.FlowerName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString()
            })
           .ToList();
        }
        // Получение списка растений с указанием используемых компонентов
        public List<ReportFlowerComponentViewModel> GetComponentsFlower()
        {
            var components = _componentStorage.GetFullList();
            var flowers = _flowerStorage.GetFullList();
            var list = new List<ReportFlowerComponentViewModel>();
            foreach (var flower in flowers)
            {
                var record = new ReportFlowerComponentViewModel
                {
                    FlowerName = flower.FlowerName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (flower.FlowerComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName, flower.FlowerComponents[component.Id].Item2));
                        record.TotalCount += flower.FlowerComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        // Сохранение компонент в файл-Word
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = _componentStorage.GetFullList()
            });
        }
        // Сохранение растения в файл-Word
        public void SaveFlowersToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список растений",
                Flowers = _flowerStorage.GetFullList()
            });
        }
        // Сохранение компонент с указанием растений в файл-Excel
        public void SaveFlowerComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                FlowerComponents = GetFlowerComponent()
            });
        }
        // Сохранение растений с указанием компонент в файл-Excel
        public void SaveComponentFlowerToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список растений",
                ComponentsFlower = GetComponentsFlower()
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
                Orders = GetOrders(model)
            });
        }
    }
}