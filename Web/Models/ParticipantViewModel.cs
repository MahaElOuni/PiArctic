using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ParticipantViewModel:UserModel
    {
        public int ParicipantId { get; set; }
        public virtual ICollection<RecommendationViewModel> listRecommdendation { get; set; }
        public virtual ICollection<FormViewModel> Forms { get; set; }

    }
}