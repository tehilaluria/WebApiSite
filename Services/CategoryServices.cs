using Entities;
using Repositories;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<IEnumerable<Category>> getCategoriesAsync()
        {
            return await _categoryRepository.getCategoriesAsync();
        }




    }
}
