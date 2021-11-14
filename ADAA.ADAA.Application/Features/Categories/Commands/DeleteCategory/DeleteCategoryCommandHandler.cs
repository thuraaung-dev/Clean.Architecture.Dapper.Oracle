using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Application.Exceptions;
using ADAA.ADP.Domain.Entities.Task;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.ADAA.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deleteCategoryCommandResponse = new DeleteCategoryCommandResponse();


            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.CATEGORY_ID);
            categoryToDelete.IS_ACTIVE = "N";

            if (categoryToDelete == null)
            {
                _logger.LogInformation($"Categor with id @{request.CATEGORY_ID} was not found.");
                throw new NotFoundException(nameof(Category), request.CATEGORY_ID);
            }

            var validator = new DeleteCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                deleteCategoryCommandResponse.Success = false;
                deleteCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    deleteCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            _mapper.Map(request, categoryToDelete, typeof(DeleteCategoryCommand), typeof(Category));

            if (deleteCategoryCommandResponse.Success)
            {

                deleteCategoryCommandResponse.isDeleted = await _categoryRepository.UpdateCategoryAsync(categoryToDelete);
                _logger.LogInformation($"Categor with id @{request.CATEGORY_ID} was deleted.");
            }
            return deleteCategoryCommandResponse;
        }
    }
}
