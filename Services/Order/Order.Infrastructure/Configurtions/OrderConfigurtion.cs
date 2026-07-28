using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Configurtions
{
    public class OrderConfigurtion : IEntityTypeConfiguration<Order.Core.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.UserName)
                .HasMaxLength(100);

            builder.Property(o => o.TotalPrice)
                .HasPrecision(18, 2);

            builder.Property(o => o.FirstName)
                .HasMaxLength(100);

            builder.Property(o => o.LastName)
                .HasMaxLength(100);

            builder.Property(o => o.EmailAddress)
                .HasMaxLength(255);

            builder.Property(o => o.AddressLine)
                .HasMaxLength(500);

            builder.Property(o => o.Country)
                .HasMaxLength(100);

            builder.Property(o => o.State)
                .HasMaxLength(100);

            builder.Property(o => o.ZipCode)
                .HasMaxLength(20);

            builder.Property(o => o.CardName)
                .HasMaxLength(100);

            builder.Property(o => o.CardNumber)
                .HasMaxLength(30);

            builder.Property(o => o.Expiration)
                .HasMaxLength(10);

            builder.Property(o => o.Cvv)
                .HasMaxLength(4);

            builder.Property(o => o.PaymentMethod);
        }
    }
}
