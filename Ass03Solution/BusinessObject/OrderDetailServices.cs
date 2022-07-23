using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObject
{
    public class OrderDetailServices : IOrderDetailServices
    {
        public string cn;
        public OrderDetailServices(string connection)
        {
            this.cn = connection;
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                IOrderDetailRepository orderDetailRepo = new OrderDetailRepository(cn);
                orderDetailRepo.AddOrderDetail(orderDetail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteOrderDetail(int orderId, int productId)
        {
            try
            {
                IOrderDetailRepository orderDetailRepo = new OrderDetailRepository(cn);
                orderDetailRepo.DeleteOrderDetail(orderId, productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<OrderDetail> GetList()
        {
            try
            {
                IOrderDetailRepository orderDetailRepo = new OrderDetailRepository(cn);
                return orderDetailRepo.GetList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<OrderDetail> GetListFromOrder(int orderId)
        {
            try
            {
                IOrderDetailRepository orderDetailRepo = new OrderDetailRepository(cn);
                return orderDetailRepo.GetList().Where(od => od.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OrderDetail GetOrderDetail(int orderId, int productId)
        {
            try
            {
                IOrderDetailRepository orderDetailRepo = new OrderDetailRepository(cn);
                return orderDetailRepo.GetOrderDetail(orderId, productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                IOrderDetailRepository orderDetailRepo = new OrderDetailRepository(cn);
                orderDetailRepo.UpdateOrderDetail(orderDetail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
