using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class LeerlingGemaakteOefeningen
    {
        public int ID { get; set; }
        public int LeerlingID { get; set; }

        public int AntwoordLeerling { get; set; }

        //via dit id controleren of de oe juist of fout is
        public int OefeningenID { get; set; }
        public int NiveauID { get; set; }
        //Er werd geen Datetime gebruikt voor de datum, deze datum wordt later omgezet van string naar datetime-conversie
        public String Datum { get; set; }

        public virtual Leerling leerling { get; set; }

        public virtual Level Level { get; set; }
        public virtual Oefeningen oefeningen { get; set; }
    }
}