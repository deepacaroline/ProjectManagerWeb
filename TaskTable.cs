//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagerWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskTable
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int TaskProjectID { get; set; }
        public Nullable<int> TaskParentID { get; set; }
        public int TaskPriority { get; set; }
        public System.DateTime TaskStartDate { get; set; }
        public System.DateTime TaskEndDate { get; set; }
        public int TaskOwnerID { get; set; }
        public string TaskStatus { get; set; }
    }
}
