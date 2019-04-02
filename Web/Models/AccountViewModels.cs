using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public enum Cities
    {
        Aryanah, Beja, BenArous, Bizerte, Dejrba, ElDjem, ElKef, Gabes, Gafsa, Jendouba, Kairouan, Kasserine, Kebili, Mahdia, Manouba, Medenine,
        Monastir, Nabeul, Sfax, Sidinibouzid, Siliana, Sousse, Tataouine, Tunis, Tozeur, Zaghouan, Zarzis
    }
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Email { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email/Username")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email/Username")]
        [EmailAddress]
        public string Email { get; set; }
        //[Display(Name = "IsValid")]
        //public bool IsValid { get; set; }

        //[Display(Name = "IsBlocked")]
        //public bool IsBlocked { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Role")]
        public string Role { get; set; }
        [Display(Name = "Remember password?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email/Username")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        [Display(Name = "CIN")]
        public string CIN { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password ")]
        [Compare("Password", ErrorMessage = "the new password and confirmation password don't match.")]
        public string ConfirmPassword { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [DataType(DataType.Text)]
        [EnumDataType(typeof(Cities))]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "id")]
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "image")]
        public string ImagePersonnel { get; set; }

        public string EntrepriseTranscripts { get; set; }

        [Display(Name = "photot")]
        public string Photo { get; set; }

        public string Poste { get; set; }

        public string NomSociete { get; set; }



    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email/Username")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "the new password and confirmation password don't match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
