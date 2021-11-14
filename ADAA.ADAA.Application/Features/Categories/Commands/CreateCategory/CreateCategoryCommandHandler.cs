using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Domain.Entities.Task;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.ADAA.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CreateCategoryCommandHandler> _logger;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<CreateCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCategoryCommandResponse.Success)
            {
                var category = new Category() { 
                    CATEGORY_NAME_AR = request.CATEGORY_NAME_AR,
                    CATEGORY_NAME_EN = request.CATEGORY_NAME_EN,
                    CATEGORY_DESC_AR = request.CATEGORY_DESC_AR,
                    CATEGORY_DESC_EN = request.CATEGORY_DESC_EN,
                    CATEGORY_DEPARTMENT_ID = request.CATEGORY_DEPARTMENT_ID,
                    IS_ACTIVE = "Y"            
                };


                try{
                    createCategoryCommandResponse.Id = await _categoryRepository.AddCategoryAsync(category);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Creating new category failed due to an error: {ex.Message}");
                }
                
            }

            return createCategoryCommandResponse;
        }
    }
}
