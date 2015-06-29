using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wiskunde_App.Models
{
    public class Soort
    {

        /*
         * SOORTEN:
         * optellen     3+2 = ?
         * aftrekken    3-2 = ?   maar ook splisting hoor hierbij (cfr ppt)
         * getal        adhv blinking, aantal figuurtjes,...            OPMERKING slechts 1 getal nodig (maar we vullen alle drie de velden in)
         * stipsom      3 + ... = 10 kan veranderd worden naar 10 -3 = ???
         * level 6 en 7 ???
         * level 20 ???
         */
        public int ID { get; set; }

        public string SoortNaam { get; set; }
    }
}
