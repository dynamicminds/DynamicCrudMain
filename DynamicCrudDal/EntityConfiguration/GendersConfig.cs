using DynamicCrud.Entity.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Dal.EF.CF.EntityConfiguration
{
    public class GendersConfig : IEntityTypeConfiguration<Genders>
    {
        public void Configure(EntityTypeBuilder<Genders> builder)
        {

            builder.ToTable("Genders");
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(1);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(20);

            builder.HasData(
                new Genders
                {
                    Id = 1,
                    Gender = 'M',
                    Description = "Male"
                },
                new Genders
                {
                    Id = 2,
                    Gender = 'F',
                    Description = "Female"
                },
                new Genders
                {
                    Id = 3,
                    Gender = 'T',
                    Description = "Trans Gender"
                }
             );
        }
    }
}
