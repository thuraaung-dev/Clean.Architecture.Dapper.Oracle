using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class SubCategory : AuditableEntity
    {  
        public decimal SUB_CATEGORY_ID { get; set; }
        public Int64 CATEGORY_ID { get; set; }      
        public string SUB_CATEGORY_NAME_AR { get; set; }    
        public string SUB_CATEGORY_NAME_EN { get; set; }
        public string IS_ACTIVE { get; set; }       
        public string SUB_CATEGORY_DESC_AR { get; set; }
        public string SUB_CATEGORY_DESC_EN { get; set; }
        public string P_SUB_CATEGORY_DEPARTMENT_ID { get; set; }
        public string CATEGORY_NAME_AR { get; set; }
        public string CATEGORY_NAME_EN { get; set; }
        public string CATEGORY_DESC_AR { get; set; }
        public string CATEGORY_DESC_EN { get; set; }
    }
}
