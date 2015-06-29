using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiskunde_App.Models;
using Wiskunde_App.ViewModels;

namespace Wiskunde_App.DataAccess.Repositories
{
    public interface IGebruikersrepository : IGenericRepository<ApplicationUser>
    {
        //Functie om alle schooladministrators weer te geven die reeds geregistreerd zijn in de database
        List<ApplicationUser> Toonalleschooladministrators();
    }
}
