using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class LetterLink : AuditableEntity
    {
        public decimal letter_link_id { get; set; }
        public Int64 task_id { get; set; }
        public Int64 letter_id { get; set; }
        public string lettre_type { get; set; }
        public string deleted_by { get; set; }
        public DateTime? deleted_date { get; set; }
        public string is_active { get; set; }
    }
}
