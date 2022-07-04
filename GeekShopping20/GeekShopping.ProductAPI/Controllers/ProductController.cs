﻿using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product == null)
                return NotFound();
        
            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO product)
        {
           
            if (product == null)
                return BadRequest();

            var prod = await _repository.Create(product);

            return Ok(prod);
        }


        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO product)
        {

            if (product == null)
                return BadRequest();

            var prod = await _repository.Update(product);

            return Ok(prod);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ProductVO>> Delete(long id)
        {
            var status = await _repository.Delete(id);

            if(!status)
                return BadRequest();

            return Ok(status);
        }


    }
}
