using ADAA.ADP.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.ADAA.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandResponse : BaseResponse
    {
        public DeleteCategoryCommandResponse() : base()
        {

        }

        public bool isDeleted { get; set; }
    }
}
