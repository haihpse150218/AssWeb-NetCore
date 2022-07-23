using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository
    {
        public OrderDetail GetOrderDetail(int orderId, int productId);
        public IEnumerable<OrderDetail> GetList();
        public void AddOrderDetail(OrderDetail orderDetail);
        public void UpdateOrderDetail(OrderDetail orderDetail);
        public void DeleteOrderDetail(int orderId, int productId);
    }
}
