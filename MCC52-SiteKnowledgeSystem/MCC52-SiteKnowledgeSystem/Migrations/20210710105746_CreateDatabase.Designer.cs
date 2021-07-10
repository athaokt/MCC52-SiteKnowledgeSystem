﻿// <auto-generated />
using MCC52_SiteKnowledgeSystem.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MCC52_SiteKnowledgeSystem.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210710105746_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Account", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("tb_t_Accounts");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.AccountRole", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("tb_t_AccountRoles");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("tb_m_Category");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ContentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ViewCounter")
                        .HasColumnType("int");

                    b.HasKey("ContentId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("tb_t_Contents");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("SiteId");

                    b.ToTable("tb_t_Employees");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ContentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("tb_t_Messages");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.RequestForm", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestId");

                    b.HasIndex("EmployeeId1");

                    b.ToTable("tb_t_RequestForms");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("tb_m_Roles");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteId");

                    b.ToTable("tb_m_Sites");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Account", b =>
                {
                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("MCC52_SiteKnowledgeSystem.Model.Account", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.AccountRole", b =>
                {
                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Content", b =>
                {
                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Category", "Category")
                        .WithMany("Contents")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Employee", "Employee")
                        .WithMany("Contents")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Category");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Employee", b =>
                {
                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Site", "Site")
                        .WithMany("Employees")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Message", b =>
                {
                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Content", "Content")
                        .WithMany("Messages")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Employee", "Employee")
                        .WithMany("Messages")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Content");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.RequestForm", b =>
                {
                    b.HasOne("MCC52_SiteKnowledgeSystem.Model.Employee", "Employee")
                        .WithMany("RequestForms")
                        .HasForeignKey("EmployeeId1");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Category", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Content", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Contents");

                    b.Navigation("Messages");

                    b.Navigation("RequestForms");
                });

            modelBuilder.Entity("MCC52_SiteKnowledgeSystem.Model.Site", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
