using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Configurations
{
    public class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            HasRequired<Blog>(e => e.Blog).WithMany(e => e.Comments).HasForeignKey(e => e.BlogId);
        }
    }

}
