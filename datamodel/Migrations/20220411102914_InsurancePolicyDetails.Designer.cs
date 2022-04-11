﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using datamodel;

namespace datamodel.Migrations
{
    [DbContext(typeof(cruse07_DbContext))]
    [Migration("20220411102914_InsurancePolicyDetails")]
    partial class InsurancePolicyDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("datamodel.models.InsuranceCategory", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("InsuranceCategories");
                });

            modelBuilder.Entity("datamodel.models.InsuranceDetailsModel", b =>
                {
                    b.Property<Guid>("InsurancePolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InsuranceCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InsurancePlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("insuranceProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("policyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("policyTerm")
                        .HasColumnType("int");

                    b.Property<string>("premiumPayingMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("premiumPayingTerm")
                        .HasColumnType("int");

                    b.Property<string>("sumAssured")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InsurancePolicyId");

                    b.HasIndex("InsuranceCategoryId")
                        .IsUnique();

                    b.HasIndex("InsurancePlanId")
                        .IsUnique();

                    b.ToTable("InsuranceDetailsModel");
                });

            modelBuilder.Entity("datamodel.models.InsurancePlan", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InsuranceCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("InsuranceCategoryId");

                    b.ToTable("InsurancePlans");
                });

            modelBuilder.Entity("datamodel.models.InsuranceDetailsModel", b =>
                {
                    b.HasOne("datamodel.models.InsuranceCategory", "insuranceCategory")
                        .WithOne("InsuranceDetails")
                        .HasForeignKey("datamodel.models.InsuranceDetailsModel", "InsuranceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("datamodel.models.InsurancePlan", "insurancePlan")
                        .WithOne("InsuranceDetails")
                        .HasForeignKey("datamodel.models.InsuranceDetailsModel", "InsurancePlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("insuranceCategory");

                    b.Navigation("insurancePlan");
                });

            modelBuilder.Entity("datamodel.models.InsurancePlan", b =>
                {
                    b.HasOne("datamodel.models.InsuranceCategory", "InsuranceCategory")
                        .WithMany("InsurancePlans")
                        .HasForeignKey("InsuranceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InsuranceCategory");
                });

            modelBuilder.Entity("datamodel.models.InsuranceCategory", b =>
                {
                    b.Navigation("InsuranceDetails");

                    b.Navigation("InsurancePlans");
                });

            modelBuilder.Entity("datamodel.models.InsurancePlan", b =>
                {
                    b.Navigation("InsuranceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
