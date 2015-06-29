using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiskunde_App.Models
{
    public class Level
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Thema { get; set; }

        public List<Resultaten> resultaten { get; set; }
    }
}