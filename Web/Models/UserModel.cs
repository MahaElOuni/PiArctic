using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public String CIN { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String PhoneNumber { get; set; }
        public String StreetName { get; set; }
        public String Password { get; set; }
        public String City { get; set; }
        public String Email { get; set; }
        public String Role { get; set; }
        public DateTime BirthDate { get; set; }
        public String Photo { get; set; }
        public String EntrepriseTranscripts { get; set; }
        //public String Etat { get; set; }
    }
}