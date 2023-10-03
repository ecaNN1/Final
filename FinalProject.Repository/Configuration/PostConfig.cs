using FinalProject.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository.Configuration
{
    public class PostConfig : BaseEntityConfig<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired(true);
            builder.Property(x => x.Content).IsRequired(true);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Posts).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.Genre).WithMany(x => x.Posts).HasForeignKey(x => x.GenreId);

            base.Configure(builder);
        }
    }
}
