using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class Resultaten
    {
        public int ID { get; set; }
        public int LeerlingID { get; set; }
        public int Score { get; set; }
        public int LevelID { get; set; }
        //Er werd geen Datetime gebruikt voor de datum, deze datum wordt later omgezet van string naar datetime-conversie
        public String Datum { get; set; }

        public virtual Leerling leerling { get; set; }

        public virtual Level level { get; set; }
    }
}