using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Configurations
{
    public class RecommendationConfiguration:EntityTypeConfiguration<Recommendation>
    {
        public RecommendationConfiguration()
        {
            HasKey(e => new { e.UserId, e.EventId, e.RecommendationNum });
        }
    }
}
