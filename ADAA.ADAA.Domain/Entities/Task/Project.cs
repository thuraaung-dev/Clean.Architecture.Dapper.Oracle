using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Project : AuditableEntity
    {
        public decimal project_id { get; set; }
        public string project_name_ar { get; set; }
        public string project_name_en { get; set; }
        public string project_execute_dept_id { get; set; }
        public string project_owner_dept_id { get; set; }
        public string is_active { get; set; }
        public string project_desc_ar { get; set; }
        public string project_desc_en { get; set; }
        public DateTime? project_start_date { get; set; }
        public DateTime? project_end_date { get; set; }
        public DateTime? project_live_date { get; set; }
    }
}
