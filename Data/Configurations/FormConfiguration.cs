using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class FormConfiguration:EntityTypeConfiguration<Form>
    {
        public FormConfiguration()
        {
            HasKey(e => new { e.FormId, e.UserId, e.EventId });
        }
    }
}
