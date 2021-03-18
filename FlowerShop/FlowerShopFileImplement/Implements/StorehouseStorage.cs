using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerShopFileImplement.Implements
{
    public class StorehouseStorage : IStorehouseStorage
    {
        private readonly FileDataListSingleton source;
        public StorehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<StorehouseViewModel> GetFullList()
        {
            return source.Storehouses
            .Select(CreateModel)
            .ToList();
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Storehouses
            .Where(rec => rec.StorehouseName.Contains(model.StorehouseName))
            .Select(CreateModel)
            .ToList();
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var storehouse = source.Storehouses
            .FirstOrDefault(rec => rec.StorehouseName == model.StorehouseName || rec.StorehouseId == model.StorehouseId);
            return storehouse != null ? CreateModel(storehouse) : null;
        }
        public void Insert(StorehouseBindingModel model)
        {
            int maxId = source.Storehouses.Count > 0 ? source.Storehouses.Max(rec => rec.StorehouseId) : 0;
            var element = new Storehouse
            {
                StorehouseId = maxId + 1,
                DateCreate = model.DateCreate,
                StorehouseComponents = new Dictionary<int, int>()
            };
            source.Storehouses.Add(CreateModel(model, element));
        }
        public void Update(StorehouseBindingModel model)
        {
            var element = source.Storehouses.FirstOrDefault(rec => rec.StorehouseId == model.StorehouseId);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(StorehouseBindingModel model)
        {
            Storehouse element = source.Storehouses.FirstOrDefault(rec => rec.StorehouseId == model.StorehouseId);
            if (element != null)
            {
                source.Storehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse storehouse)
        {
            storehouse.StorehouseName = model.StorehouseName;
            storehouse.FullName = model.FullName;
            storehouse.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in storehouse.StorehouseComponents.Keys.ToList())
            {
                if (!model.StorehouseComponents.ContainsKey(key))
                {
                    storehouse.StorehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.StorehouseComponents)
            {
                if (storehouse.StorehouseComponents.ContainsKey(component.Key))
                {
                    storehouse.StorehouseComponents[component.Key] = model.StorehouseComponents[component.Key].Item2;
                }
                else
                {
                    storehouse.StorehouseComponents.Add(component.Key, model.StorehouseComponents[component.Key].Item2);
                }
            }
            return storehouse;
        }
        private StorehouseViewModel CreateModel(Storehouse storehouse)
        {
            return new StorehouseViewModel
            {
                StorehouseId = storehouse.StorehouseId,
                StorehouseName = storehouse.StorehouseName,
                FullName = storehouse.FullName,
                DateCreate = storehouse.DateCreate,
                StorehouseComponents = storehouse.StorehouseComponents
                .ToDictionary(recPC => recPC.Key, recPC =>
                (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
        public bool writeOffComponentsFromStorehouse(int orderID)
        {
            foreach (var component in source.Flowers.FirstOrDefault(rec => rec.Id == source.Orders.FirstOrDefault(order => order.Id == orderID).FlowerId).FlowerComponents)
            {
                int count = component.Value * source.Orders.FirstOrDefault(rec => rec.Id == orderID).Count;
                foreach (Storehouse storehouse in source.Storehouses)
                {
                    if (storehouse.StorehouseComponents.ContainsKey(component.Key))
                    {
                        count -= storehouse.StorehouseComponents[component.Key];
                    }
                }
                if (count > 0)
                {
                    return false;
                }
            }

            foreach (var component in source.Flowers.FirstOrDefault(rec => rec.Id == source.Orders.FirstOrDefault(order => order.Id == orderID).FlowerId).FlowerComponents)
            {
                int count = component.Value * source.Orders.FirstOrDefault(rec => rec.Id == orderID).Count;
                foreach (Storehouse storehouse in source.Storehouses)
                {
                    if (storehouse.StorehouseComponents.ContainsKey(component.Key))
                    {
                        if (storehouse.StorehouseComponents[component.Key] > count)
                        {
                            storehouse.StorehouseComponents[component.Key] -= count;
                            break;
                        }
                        else
                        {
                            count -= storehouse.StorehouseComponents[component.Key];
                            storehouse.StorehouseComponents[component.Key] = 0;
                        }
                    }
                }
            }
            return true;
        }
    }
}