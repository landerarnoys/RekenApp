using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Services
{
    public interface ILeerlingservice
    {
        List<Leerling> Haalleerlingenvanschoolop(int LeerlingschoolID);
        Leerling HaalLeerlingopmetID(int id);

        Leerling Updateleerling(Leerling leerling);
        Leerling Verwijderleerling(int id);

        Leerling Voegleerlingtoe(Leerling leerling);
    }
}