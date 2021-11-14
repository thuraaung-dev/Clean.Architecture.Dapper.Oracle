using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Application.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        private readonly ILogger<GetCategoriesListQueryHandler> _logger;

        public GetCategoriesListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<GetCategoriesListQueryHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Getting the list of category for department {request.P_CATEGORY_DEPARTMENT_ID} ");
            var list = await _categoryRepository.GetCategoriesWithDeptId(request.P_CATEGORY_DEPARTMENT_ID);

            if (list == null)
            {
                _logger.LogInformation("Get Category List, no resutl was found");
                throw new NotFoundException(nameof(CategoryListVm), request.P_CATEGORY_DEPARTMENT_ID);
            }

            return _mapper.Map<List<CategoryListVm>>(list);
        }
    }
}
