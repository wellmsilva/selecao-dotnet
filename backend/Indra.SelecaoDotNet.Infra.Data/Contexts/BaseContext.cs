using Indra.SelecaoDotNet.Dominio.Entities;
using Indra.SelecaoDotNet.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Indra.SelecaoDotNet.Infra.Data.Contexts
{
    public class BaseContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options)
          : base(options)
        { 
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }


    }
}
