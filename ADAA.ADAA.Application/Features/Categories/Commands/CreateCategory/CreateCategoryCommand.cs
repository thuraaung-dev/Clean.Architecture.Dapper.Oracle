using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.ADAA.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string CATEGORY_NAME_AR { get; set; }
        public string CATEGORY_NAME_EN { get; set; }
        public string CATEGORY_DESC_AR { get; set; }
        public string CATEGORY_DESC_EN { get; set; }
        public string CATEGORY_DEPARTMENT_ID { get; set; }
    }
}
