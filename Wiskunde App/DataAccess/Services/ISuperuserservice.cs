using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Services
{
    public interface ISuperuserservice
    {
        List<School> AllSchools();
        School Voegschooltoe(School school);
        School HaalschoolopmetID(int id);

        School Updateschool(School school);
        School Verwijderschool(int ID);
    }
}
