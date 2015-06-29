using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Wiskunde_App.ViewModels
{
    public class WijzigWachtwoordVM
    {
        [Required]
        [DisplayName("Oud wachtwoord")]
        public String NieuwPaswoord { get; set; }

        [Required]
        [DisplayName("Nieuw wachtwoord")]
        public String HerhaalPaswoord { get; set; }

    }
}