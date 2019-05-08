using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Participant:User
    {
        public int ParicipantId { get; set; }
        public virtual ICollection<Recommendation> listRecommdendation { get; set; }
    }
}
