using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase
{
    public class SchoolContext:DbContext
    {
        public SchoolContext(DbContextOptions options) : base(options) { }
        //Roles
        public DbSet<AspNetRoles> AspNetRoles { get; set; }

        public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }

        public DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }

        public DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

        public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

        //Person Tables
        //------------------------------------------------------------------------
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<Principals> Principals { get; set; }
       
        //public DbSet<PrincipalQualifications> PrincipalQualification { get; set; }
        public DbSet<TeacherQualifications> TeacherQualifications { get; set; }

        //end of the person tables
        //---------------------------------------------------------------------------


        //ClassRoom----------------------------------------------------------------
        public DbSet<ClassRoom> ClassRoom { get; set; }
        //end of the classRoom------------------------------------------------------


        //Attendance Details---------------------------------------------------------
        public DbSet<AttendanceDetails> AttendanceDetails { get; set; }
        //end of the Attendancec Details-----------------------------------------------

        //-----------------------------------------------------------------------------
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //one to one mapping of parent student
            modelBuilder.Entity<Parents>()
                .HasOne(p => p.Student)
                .WithOne(b => b.Parent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AspNetUsers>()
                .HasOne(p => p.Role)
                .WithMany(b => b.UsrRoles)
                .OnDelete(DeleteBehavior.Restrict);



            //one to one mapping of  action details and compalin

            modelBuilder.Entity<ActionDetails>()
                .HasOne(p => p.Complain)
                .WithOne(b => b.ActionDetail)
                .OnDelete(DeleteBehavior.Restrict);

            //one to one mapping of Ternary

            modelBuilder.Entity<Ternary>()
                .HasOne(p => p.Teacher)
                .WithMany(b => b.TernaryTeacher)
                .OnDelete(DeleteBehavior.Restrict);

            //one to many mapping with ternary and marks details
            modelBuilder.Entity<MarksDetails>()
               .HasOne(p => p.Ternary)
               .WithMany(b => b.MarksDetails)
               .OnDelete(DeleteBehavior.Restrict);

            //one to many mapping with tcomplainee and user
            modelBuilder.Entity<ComplainDetails>()
               .HasOne(p => p.Users)
               .WithMany(b => b.Complains)
               .OnDelete(DeleteBehavior.Restrict);

            //one to many mapping with Notecomment and user
           

            //Teaches-----------------------------------------------
           


            //---------------------------------------------------------------------

            modelBuilder.Entity<AspNetUserRoles>()
            .HasKey(t => new { t.UserId, t.RoleId });

            modelBuilder.Entity<AspNetUserTokens>()
            .HasKey(t => new { t.UserId, t.LoginProvider,t.Name});

            modelBuilder.Entity<AspNetUserLogins>()
            .HasKey(t => new { t.LoginProvider, t.ProvideKey });

            //modelBuilder.Entity<ClassRoom>()
            // .HasMany(p => p.TeachesL)
            // .WithOne(b => b.ClassDetails)
            // .OnDelete(DeleteBehavior.Restrict);

            //  modelBuilder.Entity<PrincipalQualifications>()
            //.HasKey(c => new { c.Qualification, c.PrincipalId });

            modelBuilder.Entity<TeacherQualifications>()
            .HasKey(c => new { c.Qualification, c.TeacherId });



           
          


            //for Ternary Class-----------------------------
           // modelBuilder.Entity<Ternary>()
           //.HasKey(t => new { t.SubjectId, t. });

         
            //--------------------------------------------------------------------------

            //for ClassesWithSubject------------------------------------------------
            modelBuilder.Entity<ClassWithSubjects>()
           .HasKey(t => new { t.SubjectId, t.ClassRoomId });

            modelBuilder.Entity<ClassWithSubjects>()
                .HasOne(pt => pt.Subject)
                .WithMany(p => p.ClassesOfSubject)
                .HasForeignKey(pt => pt.SubjectId);

            modelBuilder.Entity<ClassWithSubjects>()
                .HasOne(pt => pt.GetClassRoom)
                .WithMany(t => t.SubjectOfClass)
                .HasForeignKey(pt => pt.ClassRoomId);
            //----------------------------------------------------------------------------------

            //unique admition number

            modelBuilder.Entity<Students>()
                .HasIndex(u => u.AdmissionNumber)
                .IsUnique();


            base.OnModelCreating(modelBuilder);
        }
        //---------------------------------------------------------------------------------


        //Homework------------------------------------------------------------------------
        public DbSet<HomeworkDetails> HomeworkDetails { get; set; }
        //end of the home work------------------------------------------------------------


        //Complain-------------------------------------------------------------------------
        public DbSet<ComplainDetails> ComplainDetails { get; set; }
        public DbSet<ActionDetails> ActionDetails { get; set; }
        //end of the complain----------------------------------------------------------------


        //subject & marks-------------------------------------------------------------------------------
        public DbSet<Subject> Subject { get; set; }
        public DbSet<ClassWithSubjects> ClassWithSubjects { get; set; }
        public DbSet<MarksDetails> MarkDetails { get; set; }
        public DbSet<MarkCalculations> MarkCalculations { get; set; }
       
        public DbSet<Ternary> Ternary { get; set;}
        public DbSet<SyllabusOutlineWithTernary> SyllabusOutlineWithTernary { get; set; }
        //end o f the subject-------------------------------------------------------------------


        //Note ---------------------------------------------------------------------------------------
        public DbSet<NoteDetails> NoteDetails { get; set; }
        public DbSet<NoteCommentDetails> NoteCommentDetails { get; set; }
       
        //end of the note-------------------------------------------------------------------------------

        //----------------Achievement
        public DbSet<AchievementDetails> AchievementDetails { get; set; }
        //---------------------------------------------------------------------------------
       
        //----------notice-------------------
        public DbSet<Notice> Notice { get; set; }
        //---------------------------------
    }
}
