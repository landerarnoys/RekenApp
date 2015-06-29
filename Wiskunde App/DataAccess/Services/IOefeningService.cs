using System;
using System.Collections.Generic;
using Wiskunde_App.Models;
namespace Wiskunde_App.DataAccess.Services
{
    public interface IOefeningService 
    {
        Oefeningen getOefeningById(int id);
        Resultaten addResultaat(Resultaten resultaat);
        List<Oefeningen> getAlleOefeningen();
    }
}
