﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB11V2Entities : DbContext
    {
        public DB11V2Entities()
            : base("name=DB11V2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseSemester_MTM> CourseSemester_MTM { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeCourseSemester_MTM> EmployeeCourseSemester_MTM { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Timeslot> Timeslots { get; set; }
        public virtual DbSet<Timetable> Timetables { get; set; }
        public virtual DbSet<TimetableTimeslot_MTM> TimetableTimeslot_MTM { get; set; }
        public virtual DbSet<WorkingDay> WorkingDays { get; set; }
    }
}
