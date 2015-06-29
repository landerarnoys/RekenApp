using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class School
    {
        public int ID { get; set; }

        [Required]
        public string Naam { get; set; }
        [Required]
        public string Adres { get; set; }

        [Required]
        public int Huisnummer { get; set; }

        [Required]
        public int Postcode { get; set; }

        [Required]
        public string Gemeente { get; set; }

        [Required]
        //School logo
        public String LogoUrl { get; set; }

        [Required]
        //School URL
        public String Url { get; set; }


        public List<Klas> klassen { get; set; }

        //public List<Leerling> leerlingen { get; set; }
    }
}