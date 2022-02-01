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
    public class OrasConfiguration : IEntityTypeConfiguration<Oras>
    {
        public void Configure(EntityTypeBuilder<Oras> builder)
        {
            builder.Property(x => x.Nume).HasColumnType("nvarchar(200)").HasMaxLength(200);
            builder.HasKey(x => x.Id);
            

        }
    }
}
