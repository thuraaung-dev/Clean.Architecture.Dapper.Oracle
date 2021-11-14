using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Application.Features.SubCategories.Queries
{
    public class GetSubCategoriesListFromMainQuery : IRequest<List<SubCategoryListVm>>
    {
        public string category_id;
    }
}
