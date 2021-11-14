using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Application.Features.SubCategories.Queries
{
    public class SubCategoryListVm
    {
        public Guid SUB_CATEGORY_ID { get; set; }
        public Int64 CATEGORY_ID { get; set; }
        public string SUB_CATEGORY_NAME_AR { get; set; }
        public string SUB_CATEGORY_NAME_EN { get; set; }
        public string IS_ACTIVE { get; set; }
    }
}
