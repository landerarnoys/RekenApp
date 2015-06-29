using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class Oefeningen
    {
        public int ID { get; set; }
        public int Getal1 { get; set; }
        public int Getal2 { get; set; }

        public int Getal3 { get; set; }

        //3 soorten oefeningen: pls min en getal
        //Boolean staat op true indien de oefening + is en op false indien de oefening - is
        public int SoortID { get; set; }

        public virtual Soort soort { get; set; }

    }
}