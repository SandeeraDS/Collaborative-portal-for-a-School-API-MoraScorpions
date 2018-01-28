using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TestFullDatabase;

namespace TestFullDatabase.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20180121151957_Seventh")]
    partial class Seventh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestFullDatabase.Models.AchievementDetails", b =>
                {
                    b.Property<int>("AchievementID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Details")
                        .IsRequired();

                    b.Property<string>("StudentId")
                        .IsRequired();

                    b.HasKey("AchievementID");

                    b.HasIndex("StudentId");

                    b.ToTable("AchievementDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.ActionDetails", b =>
                {
                    b.Property<int>("ActionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<bool>("ActionTaken");

                    b.Property<int>("ComplainId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Satisfaction");

                    b.Property<string>("TeachersUserId");

                    b.HasKey("ActionId");

                    b.HasIndex("ComplainId")
                        .IsUnique();

                    b.HasIndex("TeachersUserId");

                    b.ToTable("ActionDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Admin", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.HasKey("UserId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450);

                    b.Property<string>("ProvideKey")
                        .HasMaxLength(450);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.HasKey("LoginProvider", "ProvideKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<string>("RoleId")
                        .HasMaxLength(450);

                    b.HasKey("UserId", "RoleId");

                    b.HasAlternateKey("RoleId", "UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(450);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Image");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<string>("LockoutEnd");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(450);

                    b.Property<string>("Name")
                        .HasMaxLength(450);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasAlternateKey("LoginProvider", "Name", "UserId");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AttendanceDetails", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("P_Id")
                        .IsRequired();

                    b.Property<bool>("PresentAbsent");

                    b.HasKey("AttendanceId");

                    b.HasIndex("P_Id");

                    b.ToTable("AttendanceDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.ClassRoom", b =>
                {
                    b.Property<int>("ClassRoomId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassRoomName")
                        .IsRequired();

                    b.HasKey("ClassRoomId");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("TestFullDatabase.Models.ClassWithSubjects", b =>
                {
                    b.Property<int>("SubjectId");

                    b.Property<int>("ClassRoomId");

                    b.HasKey("SubjectId", "ClassRoomId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("ClassWithSubjects");
                });

            modelBuilder.Entity("TestFullDatabase.Models.ComplainDetails", b =>
                {
                    b.Property<int>("ComplainId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Anonymous");

                    b.Property<DateTime>("ComplainDate");

                    b.Property<string>("ComplaineeId")
                        .IsRequired();

                    b.Property<string>("ComplainerId")
                        .IsRequired();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<bool>("Status");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.Property<string>("UsersId");

                    b.HasKey("ComplainId");

                    b.HasIndex("ComplainerId");

                    b.HasIndex("UsersId");

                    b.ToTable("ComplainDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.HomeworkDetails", b =>
                {
                    b.Property<int>("HomeworkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("PDF");

                    b.Property<int>("TernaryId");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.Property<DateTime>("UploadedTime");

                    b.Property<bool>("Visibility");

                    b.Property<DateTime>("VisibilityEndDate");

                    b.Property<DateTime>("VisibilityStartDate");

                    b.HasKey("HomeworkId");

                    b.HasIndex("TernaryId");

                    b.ToTable("HomeworkDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.MarksDetails", b =>
                {
                    b.Property<int>("MarksID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Marks");

                    b.Property<string>("StudentID")
                        .IsRequired();

                    b.Property<string>("Term")
                        .IsRequired();

                    b.Property<int>("TernaryId");

                    b.HasKey("MarksID");

                    b.HasIndex("StudentID");

                    b.HasIndex("TernaryId");

                    b.ToTable("MarkDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.NoteCommentDetails", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CommentedTime");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<int>("NoteID");

                    b.Property<string>("StudentId");

                    b.Property<string>("TeacherId");

                    b.HasKey("CommentId");

                    b.HasIndex("NoteID");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("NoteCommentDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.NoteDetails", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<string>("Discription")
                        .IsRequired();

                    b.Property<string>("NoteFileName")
                        .IsRequired();

                    b.Property<string>("NoteTitle")
                        .IsRequired();

                    b.Property<string>("NoteUrl")
                        .IsRequired();

                    b.Property<string>("TeacherId")
                        .IsRequired();

                    b.Property<DateTime>("UploadedTime");

                    b.Property<bool>("Visibility");

                    b.HasKey("NoteId");

                    b.HasIndex("TeacherId");

                    b.ToTable("NoteDetails");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Parents", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<string>("StudentId")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Principals", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<string>("PrincipalGrade")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Principals");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Students", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<DateTime>("AdmissionDate");

                    b.Property<string>("AdmissionNumber")
                        .IsRequired();

                    b.Property<int>("ClassRoomId");

                    b.HasKey("UserId");

                    b.HasIndex("AdmissionNumber")
                        .IsUnique();

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SubjectCode")
                        .IsRequired();

                    b.Property<string>("SubjectName")
                        .IsRequired();

                    b.HasKey("SubjectId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("TestFullDatabase.Models.SubjectTeacher", b =>
                {
                    b.Property<int>("SubjectId");

                    b.Property<string>("TeacherId");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SujectTeacher");
                });

            modelBuilder.Entity("TestFullDatabase.Models.SyllabusOutlineWithTernary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("DoneOrNot");

                    b.Property<int>("IdTernary");

                    b.Property<string>("Outline")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IdTernary");

                    b.ToTable("SyllabusOutlineWithTernary");
                });

            modelBuilder.Entity("TestFullDatabase.Models.TeacherQualifications", b =>
                {
                    b.Property<string>("Qualification");

                    b.Property<string>("TeacherId");

                    b.HasKey("Qualification", "TeacherId");

                    b.HasAlternateKey("Qualification");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherQualifications");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Teachers", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.Property<int>("ClassRoomId");

                    b.Property<string>("TeacherGrade")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TestFullDatabase.Models.TeachesT", b =>
                {
                    b.Property<int>("ClassRoomId");

                    b.Property<string>("TeacherId");

                    b.HasKey("ClassRoomId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeachesT");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Ternary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassRoomId");

                    b.Property<int>("SubjectId");

                    b.Property<string>("TeacherId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Ternary");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AchievementDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Students", "Student")
                        .WithMany("Achievements")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.ActionDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.ComplainDetails", "Complain")
                        .WithOne("ActionDetail")
                        .HasForeignKey("TestFullDatabase.Models.ActionDetails", "ComplainId");

                    b.HasOne("TestFullDatabase.Models.Teachers")
                        .WithMany("Action")
                        .HasForeignKey("TeachersUserId");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Admin", b =>
                {
                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetRoleClaims", b =>
                {
                    b.HasOne("TestFullDatabase.Models.AspNetRoles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("TestFullDatabase.Models.AspNetRoles", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.AspNetUsers", b =>
                {
                    b.HasOne("TestFullDatabase.Models.AspNetRoles", "Role")
                        .WithMany("UsrRoles")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("TestFullDatabase.Models.AttendanceDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Students", "StdDetails")
                        .WithMany()
                        .HasForeignKey("P_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.ClassWithSubjects", b =>
                {
                    b.HasOne("TestFullDatabase.Models.ClassRoom", "GetClassRoom")
                        .WithMany("SubjectOfClass")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.Subject", "Subject")
                        .WithMany("ClassesOfSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.ComplainDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Parents", "Parent")
                        .WithMany()
                        .HasForeignKey("ComplainerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "Users")
                        .WithMany("Complains")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("TestFullDatabase.Models.HomeworkDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Ternary", "Ternary")
                        .WithMany()
                        .HasForeignKey("TernaryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.MarksDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.Ternary", "Ternary")
                        .WithMany("MarksDetails")
                        .HasForeignKey("TernaryId");
                });

            modelBuilder.Entity("TestFullDatabase.Models.NoteCommentDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.NoteDetails", "NoteDetails")
                        .WithMany("Comments")
                        .HasForeignKey("NoteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("TestFullDatabase.Models.Teachers", "Teacher")
                        .WithMany("Comments")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("TestFullDatabase.Models.NoteDetails", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Teachers", "Teacher")
                        .WithMany("NoteDetails")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.Parents", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Students", "Student")
                        .WithOne("Parent")
                        .HasForeignKey("TestFullDatabase.Models.Parents", "StudentId");

                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany("Parents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.Principals", b =>
                {
                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany("Principals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.Students", b =>
                {
                    b.HasOne("TestFullDatabase.Models.ClassRoom", "StdClass")
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.SubjectTeacher", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Subject", "Subject")
                        .WithMany("TeachersOfASubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.Teachers", "Teacher")
                        .WithMany("SubjectOfATeacher")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.SyllabusOutlineWithTernary", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Ternary", "Ternary")
                        .WithMany("SyllabusTernary")
                        .HasForeignKey("IdTernary")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.TeacherQualifications", b =>
                {
                    b.HasOne("TestFullDatabase.Models.Teachers", "Teacher")
                        .WithMany("Qualifications")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.Teachers", b =>
                {
                    b.HasOne("TestFullDatabase.Models.ClassRoom", "TchrClass")
                        .WithMany("Teacher")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.AspNetUsers", "User")
                        .WithMany("Teachers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TestFullDatabase.Models.TeachesT", b =>
                {
                    b.HasOne("TestFullDatabase.Models.ClassRoom", "ClassRoom")
                        .WithMany("ClassTeachers")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.Teachers", "Teacher")
                        .WithMany("TeachersClasses")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("TestFullDatabase.Models.Ternary", b =>
                {
                    b.HasOne("TestFullDatabase.Models.ClassRoom", "GetClassRoom")
                        .WithMany("TernaryClass")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.Subject", "Subject")
                        .WithMany("TernarySubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TestFullDatabase.Models.Teachers", "Teacher")
                        .WithMany("TernaryTeacher")
                        .HasForeignKey("TeacherId");
                });
        }
    }
}
