using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(string connectionString)
        {
            cn = connectionString;
        }

        public string cn { get; }

        public void changeUnitInStock(int pid, int unit)
        {
            try
            {
                var pro = new Product() { ProductId = pid, UnitInStock = unit };
                using (var context = new eStoreContext(cn))
                {
                    context.Products.Attach(pro);
                    context.Entry(pro).Property(p => p.UnitInStock).IsModified = true;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Can not change unit in stock");
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                var pro = GetProductByID(id);
                if (pro != null)
                {
                    using (var context = new eStoreContext(cn))
                    {

                        context.Products.Remove(pro);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Can not delete product!!!");
            }
        }

        public List<Product> GetAllProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    listProducts = db.Products.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not get all product!!!");
            }
            return listProducts;
        }

        public Product GetProductByID(int id)
        {
            var product = new Product();
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    product = db.Products.SingleOrDefault(c => c.ProductId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not find this product id!!!");
            }
            return product;
        }

        public List<Product> GetProductByName(string name)
        {
            var productList = new List<Product>();
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    productList = db.Products.Where(p => p.ProductName.ToLower().Contains(name.ToLower())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can not find this product by name!!!");
            }
            return productList;
        }

        public List<Product> GetProductByUnitInStockl(int unit)
        {
            var productList = new List<Product>();
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    productList = db.Products.Where(p => p.UnitInStock == unit).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can not find this product by UnitInStock!!!");
            }
            return productList;
        }

        public List<Product> GetProductByUnitPrice(decimal unitPrice)
        {
            var productList = new List<Product>();
            try
            {
                using (var db = new eStoreContext(cn))
                {
                    productList = db.Products.Where(p => p.UnitPrice == unitPrice).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can not find this product by Unitprice!!!");
            }
            return productList;
        }

        public int GetUnitInStock(int pid)
        {
            int Unit = 0;
            try
            {
                using (var context = new eStoreContext(cn))
                {
                    Unit = context
                        .Products
                        .Where(p => p.ProductId == pid)
                        .Select(u => u.UnitInStock)
                        .SingleOrDefault();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Can not get unit in stock");
            }
            return Unit;
        }

        public void InsertProduct(Product p)
        {
            try
            {
                using (var context = new eStoreContext(cn))
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not insert new product!!!");
            }
        }

        public void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new eStoreContext(cn))
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Can not update product!!!");
            }
        }
    }
}
