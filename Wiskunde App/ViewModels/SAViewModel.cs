using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wiskunde_App.Models;

namespace Wiskunde_App.ViewModels
{
    //Deze klasse dient om onder de superuser een nieuwe schooladmin aan een school toe te voegen
    public class SAViewModel
    {
        [Required]
        public String Voornaam {get; set;}

        [Required]
        public String Familienaam {get; set;}

        [Required]
        public int SchoolID {get; set;}
        [Required]
        public String Gebruikersnaam { get; set; }

        [Required]
        public String Wachtwoord { get; set; }

        public List<School> scholen { get; set; }

        

    }
}