using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Category : AuditableEntity
    {
        public decimal CATEGORY_ID { get; set; }      
        public string CATEGORY_NAME_AR { get; set; }
        public string CATEGORY_NAME_EN { get; set; }
        public string IS_ACTIVE { get; set; }
        public string CATEGORY_DESC_AR { get; set; }
        public string CATEGORY_DESC_EN { get; set; }
        public string CATEGORY_DEPARTMENT_ID { get; set; }
    }
}
