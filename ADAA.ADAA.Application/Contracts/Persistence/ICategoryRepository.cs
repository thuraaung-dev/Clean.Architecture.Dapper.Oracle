using ADAA.ADP.Domain.Entities.Task;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADAA.ADP.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category> 
    {
        Task<Category> GetByIdAsync(decimal id);
        Task<List<Category>> GetCategoriesWithDeptId(string last_dept_id);

        Task<int> AddCategoryAsync(Category category);

        Task<bool> UpdateCategoryAsync(Category category);
    }
}
