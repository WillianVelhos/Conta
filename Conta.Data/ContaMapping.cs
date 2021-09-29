using Conta.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Conta.Data
{
    public class ContaMapping : IEntityTypeConfiguration<Domain.Models.Conta>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Conta> builder)
        {
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome);
            builder.Property(c => c.ValorOriginal);
            builder.Property(c => c.DataPagamento);
            builder.Property(c => c.DataVencimento);
            builder.Property(c => c.ValorCorrigido);
            builder.Property(c => c.DiasAtraso);

            

            builder.OwnsOne(c => c.Regra, r =>
            {
                r.Property(c => c.Tipo)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<TipoRegra>())
                .HasColumnType($"varchar(30)");
            });
        }
    }
}