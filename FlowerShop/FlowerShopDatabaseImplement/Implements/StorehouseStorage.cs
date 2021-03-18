using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace FlowerShopDatabaseImplement.Implements
{
    public class StorehouseStorage : IStorehouseStorage
    {
        public List<StorehouseViewModel> GetFullList()
        {
            using (var context = new FlowerShopDatabase())
            {
                return context.Storehouses
                .Include(rec => rec.StorehouseComponents)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new StorehouseViewModel
                {
                    StorehouseId = rec.StorehouseId,
                    StorehouseName = rec.StorehouseName,
                    FullName = rec.FullName,
                    StorehouseComponents = rec.StorehouseComponents
                    .ToDictionary(recTC => recTC.ComponentId, recTC => (recTC.Component?.ComponentName, recTC.Count))
                })
                .ToList();
            }
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                return context.Storehouses
                .Include(rec => rec.StorehouseComponents)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.StorehouseName.Contains(model.StorehouseName))
                .ToList()
                .Select(rec => new StorehouseViewModel
                {
                    StorehouseId = rec.StorehouseId,
                    StorehouseName = rec.StorehouseName,
                    FullName = rec.FullName,
                    StorehouseComponents = rec.StorehouseComponents
                    .ToDictionary(recTC => recTC.ComponentId, recTC => (recTC.Component?.ComponentName, recTC.Count))
                })
                .ToList();
            }
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                var Storehouse = context.Storehouses
                .Include(rec => rec.StorehouseComponents)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.StorehouseName == model.StorehouseName || rec.StorehouseId == model.StorehouseId);
                return Storehouse != null ?
                new StorehouseViewModel
                {
                    StorehouseId = Storehouse.StorehouseId,
                    StorehouseName = Storehouse.StorehouseName,
                    FullName = Storehouse.FullName,
                    StorehouseComponents = Storehouse.StorehouseComponents
                    .ToDictionary(recTC => recTC.ComponentId, recTC => (recTC.Component?.ComponentName, recTC.Count))
                } :
                null;
            }
        }
        public void Insert(StorehouseBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Storehouse p = new Storehouse { StorehouseName = model.StorehouseName, FullName = model.FullName };
                        context.Storehouses.Add(p);
                        context.SaveChanges();
                        CreateModel(model, p, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(StorehouseBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Storehouses.FirstOrDefault(rec => rec.StorehouseId == model.StorehouseId);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(StorehouseBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                Storehouse element = context.Storehouses.FirstOrDefault(rec => rec.StorehouseId == model.StorehouseId);
                if (element != null)
                {
                    context.Storehouses.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse storehouse, FlowerShopDatabase context)
        {
            storehouse.StorehouseName = model.StorehouseName;
            storehouse.FullName = model.FullName;
            if (model.StorehouseId.HasValue)
            {
                var storehouseComponents = context.StorehouseComponents.Where(rec => rec.StorehouseId == model.StorehouseId.Value).ToList();
                // удалили те, которых нет в модели
                context.StorehouseComponents.RemoveRange(storehouseComponents.Where(rec => !model.StorehouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in storehouseComponents)
                {
                    updateComponent.Count = model.StorehouseComponents[updateComponent.ComponentId].Item2;
                    model.StorehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var tc in model.StorehouseComponents)
            {
                context.StorehouseComponents.Add(new StorehouseComponent
                {
                    StorehouseId = storehouse.StorehouseId,
                    ComponentId = tc.Key,
                    Count = tc.Value.Item2
                });
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    MessageBox.Show(e?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return storehouse;
        }
        public bool writeOffComponentsFromStorehouse(int orderID)
        {
            using (var context = new FlowerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var FlowerId = context.Flowers.FirstOrDefault(rec => rec.Id == context.Orders.FirstOrDefault(order => order.Id == orderID).FlowerId).Id;
                        var countOrders = context.Orders.FirstOrDefault(rec => rec.Id == orderID).Count;

                        foreach (var component in context.FlowerComponents.Where(rec => rec.FlowerId == FlowerId))
                        {
                            int countComponents = component.Count * countOrders;

                            foreach (var storehouseComponent in context.StorehouseComponents.Where(rec => rec.ComponentId == component.ComponentId))
                            {
                                if (storehouseComponent.Count > countComponents)
                                {
                                    storehouseComponent.Count -= countComponents;
                                    countComponents = 0;
                                    break;
                                }
                                else
                                {
                                    countComponents -= storehouseComponent.Count;
                                    storehouseComponent.Count = 0;
                                }
                            }
                            if (countComponents > 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("На складе нет необходимых компонентов");
                    }
                }
            }
        }
    }
}