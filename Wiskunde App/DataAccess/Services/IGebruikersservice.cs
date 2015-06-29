using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiskunde_App.Models;
using Wiskunde_App.ViewModels;

namespace Wiskunde_App.DataAccess.Services
{
    public interface IGebruikersservice
    {
        List<ApplicationUser> Toonalleschooladministrators();
    }
}
