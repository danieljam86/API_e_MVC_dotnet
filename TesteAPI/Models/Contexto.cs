using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GTISolutionTesteAPI.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
            : base("name=Contexto")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<EnderecoCliente> EnderecoCliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.rg)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.orgaoExpedicao)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.estadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.EnderecoCliente)
                .WithOptional(e => e.Cliente)
                .HasForeignKey(e => e.Cliente_id_cliente);

            modelBuilder.Entity<EnderecoCliente>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<EnderecoCliente>()
                .Property(e => e.logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<EnderecoCliente>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<EnderecoCliente>()
                .Property(e => e.complemento)
                .IsUnicode(false);

            modelBuilder.Entity<EnderecoCliente>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<EnderecoCliente>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<EnderecoCliente>()
                .Property(e => e.UF)
                .IsUnicode(false);
        }
    }
}
