using ADAA.ADP.Application.Contracts.Infrastructure;
using ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesExport;
using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Domain.Entities.Task;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesExport
{
    public class GetCategoriesExportQueryHandler : IRequestHandler<GetCategoriesExportQuery, CategoryExportFileVm>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetCategoriesExportQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _csvExporter = csvExporter;
        }
        public async System.Threading.Tasks.Task<CategoryExportFileVm> Handle(GetCategoriesExportQuery request, CancellationToken cancellationToken)
        {
            var allCategories = _mapper.Map<List<CategoryExportDto>>((await _categoryRepository.GetCategoriesWithDeptId(request.P_CATEGORY_DEPARTMENT_ID)));

            var fileData = _csvExporter.ExportToCsv(allCategories);

            var categoryExportFileDto = new CategoryExportFileVm() { ContentType = "text/csv", Data = fileData, CategoryExportFileName = $"{Guid.NewGuid()}.csv" };

            return categoryExportFileDto;
        }
    }
}
