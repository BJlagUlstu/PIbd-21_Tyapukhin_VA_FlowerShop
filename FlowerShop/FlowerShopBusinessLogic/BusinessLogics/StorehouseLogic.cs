using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class StorehouseLogic
    {
        private readonly IStorehouseStorage _storehouseStorage;
        private readonly IComponentStorage _componentStorage;
        public StorehouseLogic(IStorehouseStorage storehouseStorage, IComponentStorage componentStorage)
        {
            _storehouseStorage = storehouseStorage;
            _componentStorage = componentStorage;
        }
        public List<StorehouseViewModel> Read(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return _storehouseStorage.GetFullList();
            }
            if (model.StorehouseId.HasValue)
            {
                return new List<StorehouseViewModel> { _storehouseStorage.GetElement(model) };
            }
            return _storehouseStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StorehouseBindingModel model)
        {
            var element = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                StorehouseName = model.StorehouseName
            });
            if (element != null && element.StorehouseName == model.StorehouseName)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.StorehouseId.HasValue)
            {
                _storehouseStorage.Update(model);
            }
            else
            {
                _storehouseStorage.Insert(model);
            }
        }
        public void Delete(StorehouseBindingModel model)
        {
            var element = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                StorehouseId = model.StorehouseId
            });
            if (element == null)
            {
                throw new Exception("Склад не найден");
            }
            _storehouseStorage.Delete(model);
        }
        public void AddComponent(AddComponentBindingModel model)
        {
            var storehouse = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                StorehouseId = model.StorehouseId
            });
            var component = _componentStorage.GetElement(new ComponentBindingModel
            {
                Id = model.ComponentId
            });
            if (storehouse == null)
            {
                throw new Exception("Склад не найден");
            }
            if (component == null)
            {
                throw new Exception("Компонент не найден");
            }
            if (storehouse.StorehouseComponents.ContainsKey(model.ComponentId))
            {
                storehouse.StorehouseComponents[model.ComponentId] = (component.ComponentName, storehouse.StorehouseComponents[model.ComponentId].Item2 + model.Count);
            }
            else
            {
                storehouse.StorehouseComponents.Add(model.ComponentId, (component.ComponentName, model.Count));
            }
            _storehouseStorage.Update(new StorehouseBindingModel
            {
                StorehouseId = storehouse.StorehouseId,
                StorehouseName = storehouse.StorehouseName,
                FullName = storehouse.FullName,
                DateCreate = storehouse.DateCreate,
                StorehouseComponents = storehouse.StorehouseComponents
            });
        }
    }
}