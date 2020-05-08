using Indra.SelecaoDotNet.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indra.SelecaoDotNet.Infra.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");
            builder.Property(s => s.Nome)
                .IsRequired(false);


            builder.HasData
            (
                new Curso("Curso básico de Python", preco: 10),
                new Curso("Curso avançado de Python", preco: 25),
                new Curso("Curso básico de Asp.Net Core", preco: 10),
                new Curso("Curso básico de  UX", preco: 15),
                new Curso("Curso completo de VueJS", preco: 25)
            );
        }
    }
}
