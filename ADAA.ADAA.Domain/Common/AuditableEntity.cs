using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime? created_date { get; set; }
        public string created_by { get; set; }
        public DateTime? modified_date { get; set; }
        public string modified_by { get; set; }
    }
}
