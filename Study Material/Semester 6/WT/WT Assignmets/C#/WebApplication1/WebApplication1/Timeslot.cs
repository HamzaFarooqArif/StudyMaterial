//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timeslot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Timeslot()
        {
            this.TimetableTimeslot_MTM = new HashSet<TimetableTimeslot_MTM>();
        }
    
        public int ID { get; set; }
        public int EmployeeCourseSemesterID { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> WorkingDaysID { get; set; }
        public Nullable<bool> IsExam { get; set; }
    
        public virtual EmployeeCourseSemester_MTM EmployeeCourseSemester_MTM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimetableTimeslot_MTM> TimetableTimeslot_MTM { get; set; }
        public virtual WorkingDay WorkingDay { get; set; }
    }
}
