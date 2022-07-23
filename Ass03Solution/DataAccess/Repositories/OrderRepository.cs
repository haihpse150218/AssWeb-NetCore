using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository:IOrderRepository

    {
        public string cn;
        public OrderRepository(string connection)
        {
            this.cn = connection;
        }
        public void AddOrder(Order order)
        {
            try
            {
                using var dbContext = new eStoreContext(cn);
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
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
                using var dbContext = new eStoreContext(cn);
                var order = dbContext.Orders.Find(id);
                dbContext.Orders.Remove(order);
                dbContext.SaveChanges();
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
                using var dbContext = new eStoreContext(cn);
                return dbContext.Orders.ToList();
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
                using var dbContext = new eStoreContext(cn);
                return dbContext.Orders.Find(id);
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
                using var dbContext = new eStoreContext(cn);
                dbContext.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
