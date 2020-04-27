﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IbmAdmissions2019Entities : DbContext
    {
        public IbmAdmissions2019Entities()
            : base("name=IbmAdmissions2019Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<EducationDetail> EducationDetails { get; set; }
        public virtual DbSet<EntryTest> EntryTests { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<StudentProgram> StudentPrograms { get; set; }
        public virtual DbSet<TestCenter> TestCenters { get; set; }
        public virtual DbSet<TestCenterSlot> TestCenterSlots { get; set; }
        public virtual DbSet<UserLoginHistory> UserLoginHistories { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<StudentTest> StudentTests { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<StudentEducation> StudentEducations { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
    
        public virtual ObjectResult<StudentDetails_Result> StudentDetails(Nullable<int> studentId)
        {
            var studentIdParameter = studentId.HasValue ?
                new ObjectParameter("StudentId", studentId) :
                new ObjectParameter("StudentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<StudentDetails_Result>("StudentDetails", studentIdParameter);
        }
    }
}
