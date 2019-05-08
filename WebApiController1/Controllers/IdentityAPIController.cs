using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Web.Models;
using Domain.Entities;
using Service.IServices;
using System.Net.Mail;
using System.IO;

namespace WebApiController1.Controllers
{
    public class IdentityAPIController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public IdentityAPIController()
        {

        }
        public IdentityAPIController(ApplicationUserManager userManager , ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

            }
            private set
            {
                _signInManager = value;
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("api/LOGIN")]

        [HttpPost]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {


            if (ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    return NotFound();
                }

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, change to shouldLockout: true
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
                IUserService ics = new UserService();
                User c = new User();
                c = ics.Get(t => t.Email == model.Email);
                if (result == SignInStatus.Success)
                {
                    return Ok(c);

                }
                else if (result == SignInStatus.LockedOut)
                {
                    return NotFound();
                }
                else if (result == SignInStatus.RequiresVerification)
                {
                    return NotFound();
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return NotFound();
                }
                // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            }
            else
            {
                return NotFound();
            }
        }

        [Route("api/Register")]

        [HttpPost]
        public async Task<IHttpActionResult> Register(RegisterViewModel cm)
        {

            User c = new User();
            c.PhoneNumber = "55303692";
            c.BirthDate =DateTime.Today;
            c.Role = "President";
            c.City = "ddd";
            c.Etat = "pending";
            c.CIN = "12345679";
            c.FName = "haha";
            c.LName = "ll";
            c.City = "Paris";
            c.StreetName = "266 avenue Daumesnil";
            c.Email = "anis@esprit.tn";
            c.UserName = c.Email;
            c.Id = 10;
            c.Photo = "ddd";
            var mp = "A" + RandomStringGenerator() + "-78";
            c.Password = mp;
            var result = await UserManager.CreateAsync(c, mp);

            if (result.Succeeded)
            {
                try
                { 
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    MailMessage message2 = new MailMessage("summerchart1@gmail.com", cm.Email, "(Levio)Registration Succeeded", "Bonjour Mr " + cm.FName + " " + cm.LName +
                       "Your Registration has succeeded and your password is  " + mp);
                    string schemaa = "\n  <h1> Levio </h1>";
                    message2.Body = message2.Body + schemaa;
                    message2.IsBodyHtml = true;
                    SmtpClient clientt = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("", "");
                    client.Send(message2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                //  await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                // Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
                // Envoyer un message électronique avec ce lien
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirmez votre compte", "Confirmez votre compte en cliquant <a href=\"" + callbackUrl + "\">ici</a>");

                return Ok("Done");
            }


            return NotFound();
        }
        public static String RandomStringGenerator()
        {
            String randomString = Path.GetRandomFileName();
            randomString = randomString.Replace(".", string.Empty);
            return randomString;
        }
    }
}
