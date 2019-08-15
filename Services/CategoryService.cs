using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermercado.Domain.Models;
using Supermercado.Domain.Repositories;
using Supermercado.Domain.Services;
using Supermercado.Domain.Services.Communication;

namespace Supermercado.Services
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

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if(existingCategory == null)
                return new CategoryResponse("Category not found!");

            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch(Exception ex)
            {
                return new CategoryResponse($"Error: {ex.Message}");

            }

        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch(Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the category: {ex.Message}");
            }
        }

        public Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}