//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IbmAdmissions2019
{
    using System;
    using System.Collections.Generic;
    
    public partial class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program()
        {
            this.StudentPrograms = new HashSet<StudentProgram>();
        }
    
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int DegreeId { get; set; }
    
        public virtual Degree Degree { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentProgram> StudentPrograms { get; set; }
    }
}
