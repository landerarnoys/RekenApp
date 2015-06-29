using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wiskunde_App.Models
{
    public class Leerling
    {
        public int ID { get; set; }
        public String Voornaam { get; set; }
        public String Familienaam { get; set; }
        
        [Range(1,99)]
        public int Klasnummer { get; set; }

        public int? KlasID { get; set; }

        public int? SchoolID { get; set; }

        public int Level{ get; set; }
        public int GemaakteOefeningen { get; set; }

        [Display(Name = "Foto leerling")]
        public String FotoLeerling { get; set; }

        //Lijst klassen ophalen
        [NotMapped]
        public List<LeerkrachtSchoolKlas> klassen { get; set; }

        public virtual Klas klas { get; set; }

        //public virtual School school { get; set; }

        //public List<Resultaten> resultaten { get; set; }






    }
}