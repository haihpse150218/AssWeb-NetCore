using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository:IOrderDetailRepository
    {
        public string cn;
        public OrderDetailRepository(string connection)
        {
            this.cn = connection;
        }
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using var dbContext = new eStoreContext(cn);
                dbContext.OrderDetails.Add(orderDetail);
                dbContext.SaveChanges();
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
                using var dbContext = new eStoreContext(cn);
                var orderDetail = dbContext.OrderDetails.Find(orderId, productId);
                dbContext.OrderDetails.Remove(orderDetail);
                dbContext.SaveChanges();
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
                using var dbContext = new eStoreContext(cn);
                return dbContext.OrderDetails.ToList();
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
                using var dbContext = new eStoreContext(cn);
                return dbContext.OrderDetails.Find(orderId, productId);
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
                using var dbContext = new eStoreContext(cn);
                dbContext.Entry<OrderDetail>(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
