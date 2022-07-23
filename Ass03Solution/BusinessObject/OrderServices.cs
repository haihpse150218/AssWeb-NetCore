using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObject
{
    public class OrderServices : IOrderServices
    {
        public string cn;
        public OrderServices(string connection)
        {
            this.cn = connection;
        }
        public void AddOrder(Order order)
        {
            try
            {
                IOrderRepository orderRepo = new OrderRepository(cn);
                orderRepo.AddOrder(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrder(int id)
        {
            try
            {
                IOrderRepository orderRepo = new OrderRepository(cn);
                orderRepo.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Order> GetList()
        {
            try
            {
                IOrderRepository orderRepo = new OrderRepository(cn);
                return orderRepo.GetList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Order GetOrder(int id)
        {
            try
            {
                IOrderRepository orderRepo = new OrderRepository(cn);
                return orderRepo.GetOrder(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Order> SearchByDate(DateTime begin, DateTime end)
        {
            if (begin > end)
            {
                var t = begin;
                begin = end;
                end = t;
            }
            try
            {
                IOrderRepository orderRepo = new OrderRepository(cn);
                return from order in orderRepo.GetList()
                       where order.OrderDate >= begin && order.OrderDate <= end
                       select order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                IOrderRepository orderRepo = new OrderRepository(cn);
                orderRepo.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
