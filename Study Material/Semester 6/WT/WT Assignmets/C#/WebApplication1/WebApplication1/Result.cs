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
    
    public partial class Result
    {
        public int ID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public Nullable<int> CourseSemesterID { get; set; }
        public string ObtainedMarks { get; set; }
        public string TotalMarks { get; set; }
    
        public virtual CourseSemester_MTM CourseSemester_MTM { get; set; }
        public virtual Student Student { get; set; }
    }
}
