// <auto-generated />
using System;
using AdvinhaTriviasWS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdvinhaTriviasWS.Infrastructure.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221230232133_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdvinhaTriviasWS.Domain.Application.Entities.Trivias.PalavraEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Ordem")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TriviaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TriviaId");

                    b.ToTable("Palavras");
                });

            modelBuilder.Entity("AdvinhaTriviasWS.Domain.Application.Entities.Trivias.TriviaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset?>("DataFim")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DataInicio")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trivias");
                });

            modelBuilder.Entity("AdvinhaTriviasWS.Domain.Application.Entities.Trivias.PalavraEntity", b =>
                {
                    b.HasOne("AdvinhaTriviasWS.Domain.Application.Entities.Trivias.TriviaEntity", "Trivia")
                        .WithMany("Palavras")
                        .HasForeignKey("TriviaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trivia");
                });

            modelBuilder.Entity("AdvinhaTriviasWS.Domain.Application.Entities.Trivias.TriviaEntity", b =>
                {
                    b.Navigation("Palavras");
                });
#pragma warning restore 612, 618
        }
    }
}
