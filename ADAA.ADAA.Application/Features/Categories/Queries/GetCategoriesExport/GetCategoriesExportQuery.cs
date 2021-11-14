using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesExport
{
    public class GetCategoriesExportQuery : IRequest<CategoryExportFileVm>
    {
        public string P_CATEGORY_DEPARTMENT_ID { get; set; }
    }
}
