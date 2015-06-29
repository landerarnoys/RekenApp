using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class Leerkracht
    {
        public int ID { get; set; }
        public string VoorNaam{ get; set; }
        public string FamilieNaam { get; set; }

  //      public int SchoolID { get; set; }

//        public virtual School school { get; set; }


        public List<LeerkrachtSchoolKlas> klassen { get; set; }

    }
}