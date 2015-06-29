using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.Models;

namespace Wiskunde_App.ViewModels
{
    public class KlaskeuzeVM
    {
        public int KlasID {get; set;}
        public List<LeerkrachtSchoolKlas> klassen { get; set; }
    }
}