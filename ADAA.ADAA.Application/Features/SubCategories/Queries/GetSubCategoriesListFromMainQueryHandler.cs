using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Domain.Entities.Task;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADAA.ADP.Application.Features.SubCategories.Queries
{
    public class GetSubCategoriesListFromMainQueryHandler : IRequestHandler<GetSubCategoriesListFromMainQuery, List<SubCategoryListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<SubCategory> _subCategoryRepository;

        public GetSubCategoriesListFromMainQueryHandler(IMapper mapper, IAsyncRepository<SubCategory> subCategoryRepository )
        {
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
        }
        public Task<List<SubCategoryListVm>> Handle(GetSubCategoriesListFromMainQuery request, CancellationToken cancellationToken)
        {
            //var list = await _subCategoryRepository.GetByParentIdAsync(request.category_id);
            //return _mapper.Map<List<SubCategoryListVm>>(list);
            return null;
        }
    }
}
