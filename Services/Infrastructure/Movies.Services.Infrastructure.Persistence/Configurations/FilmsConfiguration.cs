using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services.Infrastructure.Persistence.Configurations
{
    public class FilmsConfiguration : IEntityTypeConfiguration<Films>
    {
        public void Configure(EntityTypeBuilder<Films> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.AgeLimit).IsRequired();

            builder.HasOne(x => x.Categories).WithMany(x => x.Films).HasForeignKey(x => x.CategoriesId);
            builder.OwnsMany(x => x.Contents).WithOwner();
        }
    }
}
