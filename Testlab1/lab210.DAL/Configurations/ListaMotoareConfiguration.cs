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
    public class ListaMotoareConfiguration : IEntityTypeConfiguration<ListaMotoare>
    {
        public void Configure(EntityTypeBuilder<ListaMotoare> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Motor).WithMany(p => p.ListaMotoare).HasForeignKey(p => p.MotorId);
            builder.HasOne(p => p.Model).WithMany(p => p.ListaMotoare).HasForeignKey(p => p.ModelId);
        }
    }
}
