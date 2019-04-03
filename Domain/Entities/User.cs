using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //lik enty ya farouk 
    public enum Cities
    {
        Aryanah,Beja,BenArous,Bizerte,Dejrba,ElDjem,ElKef,Gabes,Gafsa,Jendouba,Kairouan,Kasserine,Kebili,Mahdia,Manouba,Medenine,
        Monastir, Nabeul,Sfax,Sidinibouzid,Siliana,Sousse,Tataouine, Tunis, Tozeur ,Zaghouan,Zarzis
    }
   
        public class User : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        [MaxLength(8)]
        [MinLength(8)]
        public String CIN { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String StreetName { get; set; }
        public String Password { get; set; }
        public override String Email { get; set; }
        [EnumDataType(typeof(Cities))]
        public String City { get; set; }
        public String Role { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public String Photo { get; set; }
        public String EntrepriseTranscripts { get; set; }
        //public bool IsBlocked { get; set; }
        //public bool IsValid { get; set; }
        public String Etat { get; set; }
        public virtual ICollection<Blog>  Blogs { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }

    public class CustomUserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }

    }

    public class CustomUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
    }

    public class CustomUserClaim : IdentityUserClaim<int>
    {

    }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}
