using Indra.SelecaoDotNet.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indra.SelecaoDotNet.Infra.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .IsRequired();

            builder.Property(x => x.Nome)
                  .IsRequired();

            builder.Property(x => x.Email)
                 .IsRequired();

            builder.HasMany(x => x.Cartoes)
                    .WithOne(x => x.Usuario)
                    .HasForeignKey(x => x.Usuario_Id);

            builder.HasMany(x => x.Pagamentos)
              .WithOne(x => x.Usuario)
              .HasForeignKey(x => x.Usuario_Id);

            builder.ToTable("Usuario");
        }
    }
}
