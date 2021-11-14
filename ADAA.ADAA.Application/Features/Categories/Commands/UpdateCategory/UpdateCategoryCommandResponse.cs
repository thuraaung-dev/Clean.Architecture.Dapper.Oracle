using ADAA.ADP.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.ADAA.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse : BaseResponse
    {
        public UpdateCategoryCommandResponse() : base()
        {

        }

        public bool isUpdated { get; set; }
    }
}
