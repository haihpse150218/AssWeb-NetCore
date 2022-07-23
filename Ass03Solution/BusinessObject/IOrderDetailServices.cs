using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessObject {
    public interface IOrderDetailServices
    {
        public OrderDetail GetOrderDetail(int orderId, int productId);
        public IEnumerable<OrderDetail> GetList();
        public IEnumerable<OrderDetail> GetListFromOrder(int orderId);
        public void AddOrderDetail(OrderDetail orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(int orderId, int productId);
    }

}

