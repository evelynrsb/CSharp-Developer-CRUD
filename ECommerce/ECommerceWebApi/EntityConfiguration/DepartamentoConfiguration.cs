using ECommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.EntityConfiguration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamentos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Codigo).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(250);
        }
    }
}
