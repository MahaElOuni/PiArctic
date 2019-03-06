using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum Etat
    {
        InProgress, Done
    }
    public class Task
    {
        public int TaskId { get; set; }
        public Etat Etat { get; set; }
        public virtual Organizer Organizer { get; set; }
    }
}
