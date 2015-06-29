using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wiskunde_App.ViewModels
{
    public class SUViewModel
    {
        //Viewmodel voor het aanmeldingsscherm van de superuser die de administrators van verschillende scholen beheert.
        [Required(ErrorMessage = "Gebruikersnaam vereist.")]
        //[EmailAddress]
        public String Gebruikersnaam { get; set; }
        [Required(ErrorMessage = "Wachtwoord vereist.")]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength=6)]
        public String Wachtwoord { get; set; }
        [Display(Name="Remember me")]
        public bool RememberMe { get; set; }
    }
}