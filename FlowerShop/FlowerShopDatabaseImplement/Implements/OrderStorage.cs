using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FlowerShopBusinessLogic.BindingModels;
using FlowerShopBusinessLogic.Interfaces;
using FlowerShopBusinessLogic.ViewModels;
using FlowerShopDatabaseImplement.Models;
using FlowerShopBusinessLogic.Enums;

namespace FlowerShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new FlowerShopDatabase())
            {
                return context.Orders.Include(rec => rec.Flower).Include(rec => rec.Client).Include(rec => rec.Implementer)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    FlowerId = rec.FlowerId,
                    FlowerName = rec.Flower.FlowerName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty
                })
                .ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                return context.Orders.Include(rec => rec.Flower).Include(rec => rec.Client).Include(rec => rec.Implementer)
                .Where(rec => rec.Id.Equals(model.Id) || (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate == model.DateCreate) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status == OrderStatus.Принят) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется) ||
                (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Требуются_материалы))
                .ToList().Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    FlowerId = rec.FlowerId,
                    FlowerName = rec.Flower.FlowerName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty
                })
                .ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                var order = context.Orders.Include(rec => rec.Flower).Include(rec => rec.Client).Include(rec => rec.Implementer).FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    FlowerId = order.FlowerId,
                    FlowerName = order.Flower.FlowerName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    ClientId = order.ClientId,
                    ClientFIO = order.Client.ClientFIO,
                    ImplementerId = order.ImplementerId,
                    ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty
                } :
                null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                Order order = new Order
                {
                    FlowerId = model.FlowerId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                    ClientId = (int)model.ClientId,
                    ImplementerId = model.ImplementerId
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.FlowerId = model.FlowerId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                element.ClientId = (int)model.ClientId;
                element.ImplementerId = model.ImplementerId;
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new FlowerShopDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FlowerShopDatabase())
            {
                Flower element = context.Flowers.FirstOrDefault(rec => rec.Id == model.FlowerId);
                if (element != null)
                {
                    if (element.Orders == null)
                    {
                        element.Orders = new List<Order>();
                    }
                    element.Orders.Add(order);
                    context.Flowers.Update(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}