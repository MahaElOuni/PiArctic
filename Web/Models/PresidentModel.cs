using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PresidentModel :UserModel
    {
        public int Id;
        public String PhoneNumber { get; set; }
        public String Logo { get; set; }
        public String Email { get; set; }
        public String PresidentName { get; set; }
    }
}