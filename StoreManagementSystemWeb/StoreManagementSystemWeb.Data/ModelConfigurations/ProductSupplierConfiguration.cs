using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Data.ModelConfigurations
{
    public class ProductSupplierConfiguration : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder
                .HasKey(p => new { p.SupplierId, p.ProductId });
        }
    }
}
