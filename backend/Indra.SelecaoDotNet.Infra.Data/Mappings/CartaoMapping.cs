using Indra.SelecaoDotNet.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indra.SelecaoDotNet.Infra.Data.Mappings
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .IsRequired();

            builder.Property(x => x.Numero)
                  .IsRequired();


            builder.ToTable("Cartao");
        }
    }
}
