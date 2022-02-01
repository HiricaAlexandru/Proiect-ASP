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
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(x=>x.Nume).HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.Property(p => p.Pret).HasColumnType("decimal(8,2)");
        }
    }
}
