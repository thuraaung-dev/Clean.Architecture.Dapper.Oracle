using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Resources : AuditableEntity
    {
        public decimal resource_id { get; set; }
        public string resource_name_ar { get; set; }
        public string resource_name_en { get; set; }
        public string is_active { get; set; }

    }
}
