using ECommerceWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebApi.EntityConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Codigo).HasColumnName("codigo").IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("descricao").IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Preco).HasColumnName("preco").HasColumnType("decimal(15,2)").IsRequired();
            builder.Property(p => p.Status).HasColumnName("status");
            builder.Property(p => p.CodDepartamento).HasColumnName("codDepartamento").IsRequired();
            /*builder.Ignore(p => p.Departamento);*/
        }
    }
}
