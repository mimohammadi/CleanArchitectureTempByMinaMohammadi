using Core.Entities.Product;
using Domain;
using UseCase.Dto;
using UseCase.Interface;
using UseCase.Mapper;

namespace Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task AddProduct(ProductCreateDto dto)
        {
            await _repository.Insert(dto.ToModel());
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _repository.Get(id);
            await _repository.Delete(product);
        }

        public async Task<ProductDto> Get(int id)
        {
            var p = await _repository.Get(id);
            return p.ToDto();
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var lst = await _repository.GetAll();
            return lst.Select(a=>a.ToDto()).ToList();
        }

        public async Task UpdateProduct(ProductDto dto)
        {
            var p = await _repository.Get(dto.Id);
            if (p == null) throw new ArgumentNullException();

            p.Update(dto.Name, dto.Price);
            await _repository.Update(p);
        }
    }
}
