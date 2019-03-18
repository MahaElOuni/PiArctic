using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class President:User
    {
        public String EntrepriseTranscripts { get; set; }
        public String photo { get; set; }
        public String Recommendation { get; set; }
    }
}
