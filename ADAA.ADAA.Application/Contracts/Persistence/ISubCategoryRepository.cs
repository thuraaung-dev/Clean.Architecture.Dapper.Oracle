using ADAA.ADP.Domain.Entities.Task;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADAA.ADP.Application.Contracts.Persistence
{
    public interface ISubCategoryRepository : IAsyncRepository<SubCategory>
    {
        //Task<List<SubCategory>> GetSubCategoryWithMainCategoryID(string categoryId);
    }
}
