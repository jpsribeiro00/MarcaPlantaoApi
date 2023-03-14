using MarcaPlantao.Dominio.Clinicas;
using MarcaPlantao.Dominio.Consultas;
using MarcaPlantao.Dominio.Enderecos;
using MarcaPlantao.Dominio.Especializacoes;
using MarcaPlantao.Dominio.Ofertas;
using MarcaPlantao.Dominio.Plantoes;
using MarcaPlantao.Dominio.Profissionais;
using MarcaPlantao.Dominio.Usuarios;
using MarcaPlantao_Infraestrutura.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcaPlantao.Infra.Contexto
{
    public class ContextoMarcaPlantao : DbContext, IUnidadeTrabalho
    {
        public ContextoMarcaPlantao(DbContextOptions<ContextoMarcaPlantao> options) : base(options) { }

        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Especializacao> Especializacoes { get; set; }
        public DbSet<Plantao> Plantoes { get; set; }
        public DbSet<EventoClinica> EventosClinicas { get; set; }
        public DbSet<EventoProfissional> EventosProfissionais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfiguration Configuration = builder.Build();

            optionsBuilder.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoMarcaPlantao).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientCascade;

            //Consultas 

            modelBuilder
                .Entity<EventoClinica>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("View_EventosOfertaPlantao");
                    });

            modelBuilder
                .Entity<EventoProfissional>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("View_EventosProfissionais");
                    });

            base.OnModelCreating(modelBuilder);
        }

        public Task<int> CompletarAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
