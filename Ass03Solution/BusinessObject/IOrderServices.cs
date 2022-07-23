using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessObject
{
    public interface IOrderServices
    {
        public Order GetOrder(int id);
        public IEnumerable<Order> GetList();
        public IEnumerable<Order> SearchByDate(DateTime begin, DateTime end);
        public void AddOrder(Order order);
        public void UpdateOrder(Order order);
        public void DeleteOrder(int id);
    }
}


