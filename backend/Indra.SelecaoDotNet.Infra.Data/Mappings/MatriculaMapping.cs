using Indra.SelecaoDotNet.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Infra.Data.Mappings
{
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Curso)
                .WithMany(x => x.Matriculas)
                .HasForeignKey(x => x.Curso_Id);

            builder.HasOne(x => x.Usuario)
                 .WithMany(x => x.Matriculas)
                 .HasForeignKey(x => x.Usuario_Id);

            builder.HasOne(x => x.Pagamento)
                .WithOne(x => x.Matricula)
                .HasForeignKey<Pagamento>(b => b.Matricula_Id); 

            builder.ToTable("Matricula");
        }
    }
}
