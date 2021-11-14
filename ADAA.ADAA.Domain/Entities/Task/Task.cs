using ADAA.ADP.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Domain.Entities.Task
{
    public class Task : AuditableEntity
    {      
        public decimal task_id { get; set; }
        public string task_title { get; set; }       
        public string task_priority { get; set; }      
        public string task_details { get; set; }       
        public string assigned_to { get; set; }        
        public DateTime? task_start_date { get; set; }       
        public DateTime? task_end_date { get; set; }      
        public string assigned_from { get; set; }       
        public string is_favorite { get; set; }       
        public string is_frequent { get; set; }       
        public string is_active { get; set; }     
        public int KPIId { get; set; }      
        public int otherKPIId { get; set; }
        public int KPIFlag { get; set; }       
        public int? project_id { get; set; }      
        public int? completion_rate { get; set; }       
        public int? task_hours { get; set; }      
        public int? ADAA_MINUTES { get; set; }      
        public int? avg_Hours { get; set; }      
        public int? avg_Minutes { get; set; }       
        public string assigned_to_dept_id { get; set; }   
        public int? Category_id { get; set; }       
        public int? sub_category_id { get; set; }       
        public int? system_id { get; set; }   
        public string status_code { get; set; }    
        public int? resource_id { get; set; }     
        public string resource_ref_no { get; set; }      
        public DateTime? resource_ref_date { get; set; }        
        public string task_type { get; set; }      
        public int? parent_task_id { get; set; }       
        public string close_note { get; set; }        
        public int? meeting_id { get; set; }       
        public string[] assigned_to_Array { get; set; }
        public string task_Attachment { get; set; }
        public string startDateString { get; set; }
        public string endDateString { get; set; }
        public Int64 taskCompletionStatus { get; set; }
        public Int64 isAdaaTopInstruction { get; set; }
        public Int64? followUpLetterId { get; set; }
        public string followUpLetterDesc { get; set; }
        public string followUpLetterType { get; set; }
        public Int64? existingFollowUpLetterId { get; set; }
        public string existingFollowUpLetterType { get; set; }
    }
}
