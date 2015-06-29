using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class Klas
    {
        public int ID { get; set; }
        public string KlasNaam { get; set; }

        [NotMapped]
        public int SchoolID { get; set; }

       // public int LeerkrachtID { get; set; }
        public int MaximumAantalLeerlingen { get; set; }
        
        public virtual School school { get; set; }

   //     public virtual Leerkracht Leerkracht { get; set; }

        public virtual List<Leerling> leerlingen { get; set; }
    }
}