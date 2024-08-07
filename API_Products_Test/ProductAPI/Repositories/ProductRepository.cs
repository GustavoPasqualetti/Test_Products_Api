using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Http.HttpResults;
using ProductAPI.Context;
using ProductAPI.Domains;
using ProductAPI.Interfaces;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext? _context;
        public void AddProduct(Products product)
        {
            _context!.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Products product = _context!.Products.Find(id)!;

            _context.Products.Remove(product!);
            _context.SaveChanges();
        }

        public Products GetById(Guid id)
        {
            return _context!.Products.FirstOrDefault(x => x.IdProduct == id)!;
        }

        public List<Products> GetProducts()
        {
            return _context!.Products.ToList()!;
        }

        public void Update(Guid id, Products product)
        {
            Products FindProduct = _context!.Products.Find(id)!;
            if (FindProduct != null)
            {
                FindProduct.Name = product.Name;
                FindProduct.Price = product.Price;
            }
            _context.Update(FindProduct!);

            _context.SaveChanges();
        }
    }
}
