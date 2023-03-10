// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseService))]
    partial class DatabaseServiceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.SystemEntities.GeneralSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.ToTable("GeneralSetting", "base");
                });

            modelBuilder.Entity("Domain.SystemEntities.LogManagment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ClassName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("MethodName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("StackTrace")
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogManagment", "base");
                });

            modelBuilder.Entity("Domain.TechnoLifeProducts.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float?>("DicsountPersentage")
                        .HasColumnType("real");

                    b.Property<string>("Hdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("MonitorSize")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal?>("NormalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProcessorCache")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductProvider")
                        .HasColumnType("int");

                    b.Property<int>("ProductType")
                        .HasColumnType("int");

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Product", "app");
                });

            modelBuilder.Entity("Domain.TechnoLifeProducts.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage", "app");
                });

            modelBuilder.Entity("Domain.TechnoLifeProducts.ProductSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dimantions")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductSpecification", "app");
                });

            modelBuilder.Entity("Domain.TechnoLifeProducts.ProductImage", b =>
                {
                    b.HasOne("Domain.TechnoLifeProducts.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.TechnoLifeProducts.ProductSpecification", b =>
                {
                    b.HasOne("Domain.TechnoLifeProducts.Product", "Product")
                        .WithOne("ProductSpecification")
                        .HasForeignKey("Domain.TechnoLifeProducts.ProductSpecification", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.TechnoLifeProducts.Product", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("ProductSpecification")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
