using Foobar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foobar.Persistence.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {

            ToTable("Products");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("ProductID");

            Property(x => x.Name)
                .HasColumnName("ProductName")
                .HasMaxLength(40)
                .IsRequired();

            HasOptional(x => x.Supplier)
                .WithMany()
                .HasForeignKey(x => x.SupplierId);

            Property(x => x.SupplierId)
                .IsOptional()
                .HasColumnName("SupplierID");

            HasOptional(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId);

            Property(x => x.CategoryId)
                .HasColumnName("CategoryID");

            Property(x => x.QuantityPerUnit)
                .HasMaxLength(20);

        }
    }
}
