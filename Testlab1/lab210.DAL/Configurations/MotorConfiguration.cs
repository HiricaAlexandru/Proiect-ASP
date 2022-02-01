using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab210.DAL.Entitati;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace lab210.DAL.Configurations
{
    public class MotorConfiguration : IEntityTypeConfiguration<Motor>
    {
        public void Configure(EntityTypeBuilder<Motor> builder)
        {
            builder.Property(x=>x.Nume).HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(p => p.Pret).HasColumnType("decimal(8,2)");
            builder.HasMany(x => x.ListaMotoare);

        }
    }
}
