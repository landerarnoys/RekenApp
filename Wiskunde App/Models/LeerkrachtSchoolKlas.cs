using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class LeerkrachtSchoolKlas
    {
        public int ID { get; set; }
        public int? SchoolID { get; set; } 
        public int? KlasID { get; set; }
        public int? LeerKrachtID { get; set; }
        public virtual School school { get; set; }
        public virtual Klas klas { get; set; }

        public virtual Leerkracht leerkracht { get; set; }


    }
}