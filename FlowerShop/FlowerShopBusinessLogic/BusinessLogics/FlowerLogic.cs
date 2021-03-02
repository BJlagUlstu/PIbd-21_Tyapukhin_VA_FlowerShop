using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace FlowerShopBusinessLogic.BusinessLogics
{
    public class FlowerLogic
    {
        private readonly IFlowerStorage _componentStorage;
        public FlowerLogic(IFlowerStorage componentStorage)
        {
            _componentStorage = componentStorage;
        }
        public List<FlowerViewModel> Read(FlowerBindingModel model)
        {
            if (model == null)
            {
                return _componentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<FlowerViewModel> { _componentStorage.GetElement(model) };
            }
            return _componentStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(FlowerBindingModel model)
        {
            var element = _componentStorage.GetElement(new FlowerBindingModel
            {
                FlowerName = model.FlowerName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть растение с таким названием");
            }
            if (model.Id.HasValue)
            {
                _componentStorage.Update(model);
            }
            else
            {
                _componentStorage.Insert(model);
            }
        }
        public void Delete(FlowerBindingModel model)
        {
            var element = _componentStorage.GetElement(new FlowerBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Растение не найдено");
            }
            _componentStorage.Delete(model);
        }
    }
}