using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Participants : AuditableEntity
    {
        public decimal serial { get; set; }
        public Int64 task_id { get; set; }
        public string participant_user_id { get; set; }
        public string participant_notes { get; set; }
        public string is_active { get; set; }
    }
}
