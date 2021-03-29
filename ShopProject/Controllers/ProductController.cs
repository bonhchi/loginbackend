using AutoMapper;
using Common.Http;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Products;
using Service.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [EnableCors("LoginCors")]
    public class ProductController : BaseController
    {
        private readonly IProductService _product;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService product, IWebHostEnvironment webHostEnvironment)
        {
            _product = product;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("api/product")]
        public IActionResult Index()
        {
            var products = _product.GetAllProduct();
            return Ok(products);
        }

        [HttpPost("api/product/add")]
        [Consumes("multipart/form-data")]
        public IActionResult Add([FromForm] ProductDto product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image == null || image.Length == 0)
                    product.Image = "abc.jpg";
                else
                {
                    var path = Path.Combine(_webHostEnvironment.ContentRootPath, @"C:\Code\Work\LoginProject\ShopProject\Resource\Images");//clean path
                    string filePath = Path.Combine(path, image.FileName.ToString());
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                        image.CopyTo(fileStream);
                    product.Image = image.FileName;
                }
                _product.Add(product);
                return RedirectToAction("Index", "Product");
            }
            else
                return Ok(product);
        }
        [Route("api/product/edit/{id}")]
        [HttpGet]
        public IActionResult Edit([FromQuery] Guid id)
        {
            var product = _product.GetById(id);
            return Ok(product);
        }
        //Route k lấy đc id
        [HttpPost("api/product/edit/{id?}")]
        public IActionResult Edit([FromBody] ProductDto product, Guid id)
        {
            if (ModelState.IsValid)
            {
                if(id != product.Id)
                {
                    return BadRequest();
                }
                _product.Update(product);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return Ok(product);
            }
        }
        [HttpGet]
        [Route("api/product/delete/{id}")]
        public IActionResult Delete([FromQuery] Guid id)
        {
            var product = _product.GetById(id);
            return Ok(product);
        }
        [Route("api/product/delete/{id}")]
        [HttpDelete, ActionName("Delete")]
        
        public IActionResult DeleteConfirmed(Guid id)
        {
            _product.Delete(id);
            return Ok();
        }
        [HttpGet]
        [Route("api/product/detail/{id?}")]
        public IActionResult Detail(Guid id)
        {
            return Ok(_product.Detail(id));
        }
    }
}
