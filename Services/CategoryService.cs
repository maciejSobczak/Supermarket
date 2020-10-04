using System.Collections.Generic;
using System.Threading.Tasks;
using supermarket.api.Domain.Repositories;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch (System.Exception ex)
            {
                return new SaveCategoryResponse($"An error occured when saving the category: {ex.Message}");
            }
        }

        public async Task<SaveCategoryResponse> UpdateAsync(int id, Category category)
        {
            var currentCategory = await _categoryRepository.FindByIdAsync(id);

            if (currentCategory == null)
                return new SaveCategoryResponse($"Category with id {id} not found.");

            currentCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(currentCategory);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(currentCategory);
            }
            catch (System.Exception ex)
            {
                return new SaveCategoryResponse($"An error occured when updating the category: {ex.Message}");
            }
        }
    }
}
