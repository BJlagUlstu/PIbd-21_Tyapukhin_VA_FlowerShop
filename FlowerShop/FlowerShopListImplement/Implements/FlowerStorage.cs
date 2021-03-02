using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerShopListImplement.Implements
{
    public class FlowerStorage : IFlowerStorage
    {
        private readonly DataListSingleton source;
        public FlowerStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<FlowerViewModel> GetFullList()
        {
            List<FlowerViewModel> result = new List<FlowerViewModel>();
            foreach (var component in source.Flowers)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<FlowerViewModel> GetFilteredList(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<FlowerViewModel> result = new List<FlowerViewModel>();
            foreach (var flower in source.Flowers)
            {
                if (flower.FlowerName.Contains(model.FlowerName))
                {
                    result.Add(CreateModel(flower));
                }
            }
            return result;
        }
        public FlowerViewModel GetElement(FlowerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Flowers)
            {
                if (product.Id == model.Id || product.FlowerName ==
                model.FlowerName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(FlowerBindingModel model)
        {
            Flower tempProduct = new Flower
            {
                Id = 1,
                FlowerComponents = new Dictionary<int, int>()
            };
            foreach (var product in source.Flowers)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Flowers.Add(CreateModel(model, tempProduct));
        }
        public void Update(FlowerBindingModel model)
        {
            Flower tempProduct = null;
            foreach (var product in source.Flowers)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(FlowerBindingModel model)
        {
            for (int i = 0; i < source.Flowers.Count; ++i)
            {
                if (source.Flowers[i].Id == model.Id)
                {
                    source.Flowers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Flower CreateModel(FlowerBindingModel model, Flower product)
        {
            product.FlowerName = model.FlowerName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.FlowerComponents.Keys.ToList())
            {
                if (!model.FlowerComponents.ContainsKey(key))
                {
                    product.FlowerComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.FlowerComponents)
            {
                if (product.FlowerComponents.ContainsKey(component.Key))
                {
                    product.FlowerComponents[component.Key] =
                    model.FlowerComponents[component.Key].Item2;
                }
                else
                {
                    product.FlowerComponents.Add(component.Key,
                    model.FlowerComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private FlowerViewModel CreateModel(Flower product)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> flowerComponents = new
            Dictionary<int, (string, int)>();

            foreach (var pc in product.FlowerComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                flowerComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new FlowerViewModel
            {
                Id = product.Id,
                FlowerName = product.FlowerName,
                Price = product.Price,
                FlowerComponents = flowerComponents
            };
        }
    }
}