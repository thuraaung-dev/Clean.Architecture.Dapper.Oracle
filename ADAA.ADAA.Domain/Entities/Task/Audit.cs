using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Audit : AuditableEntity
    {
        public decimal serial_id { get; set; }
        public Int64 task_id { get; set; }
        public string dml_type { get; set; }
        public DateTime? dml_date { get; set; }
        public string user_id { get; set; }
        public string machine_name { get; set; }
        public string column_name { get; set; }
        public string old_value { get; set; }
        public string new_value { get; set; }
        public string notes { get; set; }
        public DateTime? entry_date { get; set; }
        public string is_active { get; set; }

    }
}
