using ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesList;
using ADP.ADAA.Api.Utility;
using ADP.ADAA.Application.Features.Categories.Commands.CreateCategory;
using ADP.ADAA.Application.Features.Categories.Commands.DeleteCategory;
using ADP.ADAA.Application.Features.Categories.Commands.UpdateCategory;
using ADP.Solution.Application.Features.Categories.Queries.GetCategoriesExport;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADP.ADAA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories(string P_CATEGORY_DEPARTMENT_ID)
        {
            
            GetCategoriesListQuery getCategoriesListQuery = new GetCategoriesListQuery() { P_CATEGORY_DEPARTMENT_ID = P_CATEGORY_DEPARTMENT_ID, BypassCache = false };

            var dtos = await _mediator.Send(getCategoriesListQuery);
            return Ok(dtos);
        }

        [Authorize]
        [HttpPost(Name = "AddCategory")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryCommand createEventCommand)
        {
            var response = await _mediator.Send(createEventCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await _mediator.Send(updateCategoryCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(decimal id)
        {
            var deleteCategoryCommand = new DeleteCategoryCommand() { CATEGORY_ID = id };
            var response = await _mediator.Send(deleteCategoryCommand);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("export", Name = "ExportEvents")]
        [FileResultContentType("text/csv")]
        public async Task<FileResult> ExportEvents(string DepartmentID)
        {
            var fileDto = await _mediator.Send(new GetCategoriesExportQuery() { P_CATEGORY_DEPARTMENT_ID = DepartmentID });

            return File(fileDto.Data, fileDto.ContentType, fileDto.CategoryExportFileName);
        }
    }
}
