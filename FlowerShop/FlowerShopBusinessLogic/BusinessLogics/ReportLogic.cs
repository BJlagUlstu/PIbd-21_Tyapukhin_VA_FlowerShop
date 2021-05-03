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
        private readonly IFlowerStorage _flowerStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStorehouseStorage _storehouseStorage;
        public ReportLogic(IFlowerStorage flowerStorage, IOrderStorage orderStorage, IStorehouseStorage storehouseStorage)
        {
            _flowerStorage = flowerStorage;
            _orderStorage = orderStorage;
            _storehouseStorage = storehouseStorage;
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
                foreach (var component in flower.FlowerComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        // Получение списка заказов за все время
        public List<ReportOrdersAllDatesViewModel> GetAllOrders()
        {
            return _orderStorage.GetFullList().GroupBy(x => x.DateCreate.Date)
            .Select(g => new ReportOrdersAllDatesViewModel
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
                foreach (var component in storehouse.StorehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
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
        public void SaveAllOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocOrdersAllDates(new PdfInfoOrdersAllDates
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetAllOrders()
            });
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
                Orders = GetOrders(model)
            });
        }
    }
}