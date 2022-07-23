using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductByID(int id);
        List<Product> GetProductByName(string name);
        List<Product> GetProductByUnitPrice(decimal unitPrice);
        List<Product> GetProductByUnitInStockl(int unit);

        void InsertProduct(Product p);
        void UpdateProduct(Product p);
        void DeleteProduct(int id);

        int GetUnitInStock(int pid);
        void changeUnitInStock(int pid, int unit);
    }
}
