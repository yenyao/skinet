using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
	// Interface of Product Repository
	// Declares what methods are used
	public interface IProductRepository
	{
		Task<Product> GetProductByIdAsync(int id);

		Task<IReadOnlyList<Product>> GetProductsAsync();

		Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

		Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

	}
}