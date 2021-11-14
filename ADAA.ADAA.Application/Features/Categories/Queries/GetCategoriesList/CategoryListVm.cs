using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public decimal CATEGORY_ID { get; set; }
        public string CATEGORY_NAME_AR { get; set; }
        public string CATEGORY_NAME_EN { get; set; }
        public string IS_ACTIVE { get; set; }
    }
}
