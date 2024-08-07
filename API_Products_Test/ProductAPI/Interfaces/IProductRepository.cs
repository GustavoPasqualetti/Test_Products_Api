using ProductAPI.Domains;

namespace ProductAPI.Interfaces
{
    public interface IProductRepository
    {
        List<Products> GetProducts();
        void AddProduct(Products product);
        Products GetById(Guid id);
        void Delete(Guid id);
        void Update(Guid id, Products product);
    }
}
