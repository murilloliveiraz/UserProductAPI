using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProductAPI.Context;
using UserProductAPI.Data.DTOS;
using UserProductAPI.Data.Models;

namespace UserProductAPI.Services
{
    public class ProductService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public ProductService(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Product> CreateProduct([FromBody]ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<ProductDTO>> ListProducts()
        {
            return _mapper.Map<List<ProductDTO>>(_context.Products);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public async Task UpdateProduct(int id, ProductDTO productDTO)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return;
            _mapper.Map(productDTO, product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return;
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
