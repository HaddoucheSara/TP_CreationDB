using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_CreationDB.Models;
using TP_CreationDB.Vues;

namespace TP_CreationDB.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<TeacherSubjectView> TeacherSubjects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=OUJDKZJN53;Database=TP_CreationDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TeacherSubjectView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("V_Teacher_Subject");
            });
            modelBuilder.Entity<Person>().HasDiscriminator<string>("PersonType")
                 .HasValue<Student>("Student")
                 .HasValue<Teacher>("Teacher");

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Subject)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SubjectId);
                
            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TeacherId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Classe)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClassId);
        }
        public List<Student> GetStudentByStudentNumber(int studentNumber)
        {
            return this.Persons
        .FromSqlRaw("EXEC GetStudentByStudentNumber @StudentNumber={0}", studentNumber)
        .AsEnumerable()  
        .OfType<Student>()  
        .ToList();
        }



    }
}
