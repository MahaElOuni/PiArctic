using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Configurations
{
    public class BlogConfig : EntityTypeConfiguration<Blog>
    {
        public BlogConfig()
        {
            HasMany<Comment>(e => e.Comments).WithRequired(e => e.Blog).HasForeignKey(e => e.BlogId);

        }
    }
}
