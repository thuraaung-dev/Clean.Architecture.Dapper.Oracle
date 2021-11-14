using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Notes : AuditableEntity
    {
        public decimal note_id { get; set; }
        public string note_description { get; set; }
        public DateTime? deleted_date { get; set; }
        public string deleted_by { get; set; }
    }
}
