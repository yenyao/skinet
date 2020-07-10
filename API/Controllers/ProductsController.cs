using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;

namespace API.Controllers
{
    // Defines it as API controller, serves HTTP responses
    [ApiController]
    // Declares the route
    [Route("api/[controller]")]

    // Class inherits from Controller. ControllerBase is a controller w/o views
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;


        // Products controller constructor that instantiates the product repository.
        // Repository holds the methods that retrieves data.
        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductBrand> productBrandRepo,
            IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            // Automapper
            _mapper = mapper;
        }

        // Http Get method, standard no parameters
        [HttpGet]

        // Asynchronously returns a list of products.
        // CALLS THE REPOSITORY METHODS
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        // Http Get method with the id as a parameter
        [HttpGet("{id}")]

        // Asynchronously returns a single product defined by the HTTP Get.
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            // Creates a new instance of specification
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);

            // Maps the ProductToReturnDto to Product
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        // HTTP Get method with brands appended to the url
        [HttpGet("brands")]

        // Asynchronously returns a list of product brands.
        // IReadOnlyList is a list of objects that cannot be edited
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        // HTTP Get method with types appended to the url
        [HttpGet("types")]

        // Asynchronously returns a list of product types.
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

    }
}

