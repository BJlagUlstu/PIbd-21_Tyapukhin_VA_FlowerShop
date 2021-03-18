using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerShopListImplement.Implements
{
    public class StorehouseStorage : IStorehouseStorage
    {
        private readonly DataListSingleton source;
        public StorehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StorehouseViewModel> GetFullList()
        {
            List<StorehouseViewModel> result = new List<StorehouseViewModel>();
            foreach (var storehouse in source.Storehouses)
            {
                result.Add(CreateModel(storehouse));
            }
            return result;
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<StorehouseViewModel> result = new List<StorehouseViewModel>();
            foreach (var storehouse in source.Storehouses)
            {
                if (storehouse.StorehouseName.Contains(model.StorehouseName))
                {
                    result.Add(CreateModel(storehouse));
                }
            }
            return result;
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var storehouse in source.Storehouses)
            {
                if (storehouse.StorehouseId == model.StorehouseId || storehouse.StorehouseName == model.StorehouseName)
                {
                    return CreateModel(storehouse);
                }
            }
            return null;
        }
        public void Insert(StorehouseBindingModel model)
        {
            Storehouse _storehouse = new Storehouse
            {
                StorehouseId = 1,
                DateCreate = model.DateCreate,
                StorehouseComponents = new Dictionary<int, int>()
            };
            foreach (var storehouse in source.Storehouses)
            {
                if (storehouse.StorehouseId >= _storehouse.StorehouseId)
                {
                    _storehouse.StorehouseId = storehouse.StorehouseId + 1;
                }
            }
            source.Storehouses.Add(CreateModel(model, _storehouse));
        }
        public void Update(StorehouseBindingModel model)
        {
            Storehouse _storehouse = null;
            foreach (var storehouse in source.Storehouses)
            {
                if (storehouse.StorehouseId == model.StorehouseId)
                {
                    _storehouse = storehouse;
                }
            }
            if (_storehouse == null)
            {
                throw new Exception("Склад не найден");
            }
            CreateModel(model, _storehouse);
        }
        public void Delete(StorehouseBindingModel model)
        {
            for (int i = 0; i < source.Storehouses.Count; ++i)
            {
                if (source.Storehouses[i].StorehouseId == model.StorehouseId)
                {
                    source.Storehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Склад не найден");
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse storehouse)
        {
            storehouse.StorehouseName = model.StorehouseName;
            storehouse.FullName = model.FullName;
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
                    storehouse.StorehouseComponents[component.Key] =
                    model.StorehouseComponents[component.Key].Item2;
                }
                else
                {
                    storehouse.StorehouseComponents.Add(component.Key,
                    model.StorehouseComponents[component.Key].Item2);
                }
            }
            return storehouse;
        }
        private StorehouseViewModel CreateModel(Storehouse storehouse)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> _storehouseComponents = new Dictionary<int, (string, int)>();
            foreach (var sc in storehouse.StorehouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (sc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                _storehouseComponents.Add(sc.Key, (componentName, sc.Value));
            }
            return new StorehouseViewModel
            {
                StorehouseId = storehouse.StorehouseId,
                StorehouseName = storehouse.StorehouseName,
                FullName = storehouse.FullName,
                DateCreate = storehouse.DateCreate,
                StorehouseComponents = _storehouseComponents
            };
        }
        public bool writeOffComponentsFromStorehouse(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}