using lab210.DAL.Entitati;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL.Configurations
{
    public class ProducatorConfiguration : IEntityTypeConfiguration<Producator>
    {
        public void Configure(EntityTypeBuilder<Producator> builder)
        {
            builder.Property(p => p.premium).HasColumnType("decimal(8,2)");
            builder.Property(p => p.Nume).HasColumnType("nvarchar(200)").HasMaxLength(200);
           

        }
    }
}
