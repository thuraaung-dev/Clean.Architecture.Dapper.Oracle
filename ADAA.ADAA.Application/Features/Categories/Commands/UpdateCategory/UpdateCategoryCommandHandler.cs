using ADAA.ADP.Application.Contracts.Persistence;
using ADAA.ADP.Application.Exceptions;
using ADAA.ADP.Domain.Entities.Task;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADP.ADAA.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updateCategoryCommandResponse = new UpdateCategoryCommandResponse();


            var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.CATEGORY_ID);

            if (categoryToUpdate == null)
            {
                throw new NotFoundException(nameof(Category), request.CATEGORY_ID);
            }

            var validator = new UpdateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateCategoryCommandResponse.Success = false;
                updateCategoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    updateCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            _mapper.Map(request, categoryToUpdate, typeof(UpdateCategoryCommand), typeof(Category));

            if (updateCategoryCommandResponse.Success)
            {

                updateCategoryCommandResponse.isUpdated = await _categoryRepository.UpdateCategoryAsync(categoryToUpdate);
            }
            return updateCategoryCommandResponse;
        }
    }
}
