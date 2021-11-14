using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.ADAA.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryDto
    {
        public decimal CATEGORY_ID { get; set; }
        public string CATEGORY_NAME_AR { get; set; }
        public string CATEGORY_NAME_EN { get; set; }
        public string IS_ACTIVE { get; set; }
        public string CATEGORY_DESC_AR { get; set; }
        public string category_desc_en { get; set; }
        public string CATEGORY_DEPARTMENT_ID { get; set; }
    }
}
