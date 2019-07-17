using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Data.ModelConfigurations
{
    class ProductShoppingCartConfiguration: IEntityTypeConfiguration<ProductShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ProductShoppingCart> builder)
        {
            builder
                .HasKey(p => new { p.ProductId, p.ShoppingCartId });
        }
    }
}
