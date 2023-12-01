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
    public class MoviesConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128);
            builder.Property(x => x.AgeLimit).IsRequired();
            builder.Property(x => x.Episode).IsRequired();
            builder.Property(x => x.Duration).IsRequired();

            builder.HasOne(x => x.Categories).WithMany(x => x.Movie).HasForeignKey(x => x.CategoriesId);
            builder.OwnsMany(x => x.Contents).WithOwner();
        }
    }
}
