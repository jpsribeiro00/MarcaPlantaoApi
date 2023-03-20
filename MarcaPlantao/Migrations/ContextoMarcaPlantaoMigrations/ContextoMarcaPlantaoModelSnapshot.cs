﻿// <auto-generated />
using System;
using MarcaPlantao.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarcaPlantao.Migrations.ContextoMarcaPlantaoMigrations
{
    [DbContext(typeof(ContextoMarcaPlantao))]
    partial class ContextoMarcaPlantaoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EspecializacaoOferta", b =>
                {
                    b.Property<Guid>("EspecializacoesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OfertasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EspecializacoesId", "OfertasId");

                    b.HasIndex("OfertasId");

                    b.ToTable("EspecializacaoOferta");
                });

            modelBuilder.Entity("EspecializacaoProfissional", b =>
                {
                    b.Property<Guid>("EspecializacoesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfissionaisId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EspecializacoesId", "ProfissionaisId");

                    b.HasIndex("ProfissionaisId");

                    b.ToTable("EspecializacaoProfissional");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Avaliacao.AvaliacaoClinica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<Guid>("PlantaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("AvaliacaoClinicas");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Avaliacao.AvaliacaoProfissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<Guid>("PlantaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("AvaliacaoProfissionais");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Clinicas.Clinica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Consultas.EventoClinica", b =>
                {
                    b.Property<DateTime?>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.ToView("View_EventosOfertaPlantao");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Consultas.EventoProfissional", b =>
                {
                    b.Property<DateTime?>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.ToView("View_EventosProfissionais");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Enderecos.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Especializacoes.Especializacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Especializacoes");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Ofertas.Oferta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("Pagamento")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Turno")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<double>("ValorHoraExtra")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.ToTable("Ofertas");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Plantoes.Plantao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comprovante")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime");

                    b.Property<string>("Desconto")
                        .HasColumnType("varchar(200)");

                    b.Property<double>("HoraExtra")
                        .HasColumnType("float");

                    b.Property<Guid>("OfertaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfissionalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("int");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("OfertaId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Plantoes");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Profissionais.Profissional", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Profissionais");
                });

            modelBuilder.Entity("OfertaProfissional", b =>
                {
                    b.Property<Guid>("OfertasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProfissionaisId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OfertasId", "ProfissionaisId");

                    b.HasIndex("ProfissionaisId");

                    b.ToTable("OfertaProfissional");
                });

            modelBuilder.Entity("EspecializacaoOferta", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Especializacoes.Especializacao", null)
                        .WithMany()
                        .HasForeignKey("EspecializacoesId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarcaPlantao.Dominio.Ofertas.Oferta", null)
                        .WithMany()
                        .HasForeignKey("OfertasId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EspecializacaoProfissional", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Especializacoes.Especializacao", null)
                        .WithMany()
                        .HasForeignKey("EspecializacoesId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarcaPlantao.Dominio.Profissionais.Profissional", null)
                        .WithMany()
                        .HasForeignKey("ProfissionaisId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Avaliacao.AvaliacaoClinica", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Clinicas.Clinica", "Clinica")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarcaPlantao.Dominio.Profissionais.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Avaliacao.AvaliacaoProfissional", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Clinicas.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarcaPlantao.Dominio.Profissionais.Profissional", "Profissional")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Clinicas.Clinica", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Enderecos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Ofertas.Oferta", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Clinicas.Clinica", "Clinica")
                        .WithMany("Ofertas")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Plantoes.Plantao", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Clinicas.Clinica", "Clinica")
                        .WithMany("Plantoes")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarcaPlantao.Dominio.Ofertas.Oferta", "Oferta")
                        .WithMany()
                        .HasForeignKey("OfertaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarcaPlantao.Dominio.Profissionais.Profissional", "Profissional")
                        .WithMany()
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Oferta");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("OfertaProfissional", b =>
                {
                    b.HasOne("MarcaPlantao.Dominio.Ofertas.Oferta", null)
                        .WithMany()
                        .HasForeignKey("OfertasId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("MarcaPlantao.Dominio.Profissionais.Profissional", null)
                        .WithMany()
                        .HasForeignKey("ProfissionaisId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Clinicas.Clinica", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Ofertas");

                    b.Navigation("Plantoes");
                });

            modelBuilder.Entity("MarcaPlantao.Dominio.Profissionais.Profissional", b =>
                {
                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
