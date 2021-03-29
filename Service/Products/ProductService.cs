using AutoMapper;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Products;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Users
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public ProductService(IMapper mapper, IRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _repository.GetAll();
        }

        public Product GetById(Guid id)
        {
            return _repository.Find(id);
        }

        public Product Add(ProductDto product)
        {
            var item = _mapper.Map<ProductDto, Product>(product);
            _repository.Insert(item);
            return item;
        }

        public void Update(ProductDto product)
        {
            var item = _mapper.Map<ProductDto, Product>(product);
            _repository.Update(item);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public Product Detail(Guid id)
        {
            return _repository.Detail(id);
        }

        public Product Find(Guid id)
        {
            return _repository.Find(id);
        }
    }
}
