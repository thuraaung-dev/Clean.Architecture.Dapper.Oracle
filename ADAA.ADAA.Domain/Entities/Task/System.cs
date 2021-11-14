using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class System : AuditableEntity
    {
        public decimal system_id { get; set; }
        public string system_name_ar { get; set; }
        public string system_name_en { get; set; }
        public string system_desc_ar { get; set; }
        public string system_desc_en { get; set; }
        public string system_owner_dept_id { get; set; }
        public string app_id { get; set; }
        public DateTime? system_live_date { get; set; }
        public string is_active { get; set; }
       

    }
}
