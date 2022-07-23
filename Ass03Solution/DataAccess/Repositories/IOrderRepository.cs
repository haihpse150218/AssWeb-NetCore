using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderRepository
    {
        public Order GetOrder(int id);
        public IEnumerable<Order> GetList();
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(int id);
    }
}
