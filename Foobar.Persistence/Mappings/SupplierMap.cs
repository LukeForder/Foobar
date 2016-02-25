using Foobar.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foobar.Persistence.Mappings
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            ToTable("Suppliers");

            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasColumnName("SupplierID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            Property(x => x.ContactName)
                .HasMaxLength(30);

            Property(x => x.ContactTitle)
                .HasMaxLength(30);

            Property(x => x.Address)
                .HasMaxLength(60);

            Property(x => x.City)
                .HasMaxLength(15);

            Property(x => x.Region)
                .HasMaxLength(15);

            Property(x => x.PostalCode)
                .HasMaxLength(10);

            Property(x => x.Phone)
                .HasMaxLength(24);

            Property(x => x.Fax)
                .HasMaxLength(24);


        }
    }
}
