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
    [DbContext(typeof(imftenant_DbContext))]
    [Migration("20210830111307_addlastupdateddefaultvaluetoinsurancecategory")]
    partial class addlastupdateddefaultvaluetoinsurancecategory
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
                    b.Navigation("InsurancePlans");
                });
#pragma warning restore 612, 618
        }
    }
}
