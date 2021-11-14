using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Status : AuditableEntity
    {
        public string status_code { get; set; }
        public string status_name_ar { get; set; }
        public string status_name_en { get; set; }
        public string  is_active { get; set; }
    }
}
