using System;
using System.Collections.Generic;
using System.Text;
using Domain.DTOs;
using Domain.Entities;

namespace Service.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProduct();
        Product GetById(Guid id);
        Product Add(ProductDto product);
        void Update(ProductDto product);
        void Delete(Guid id);
        Product Detail(Guid id);
    }
}
