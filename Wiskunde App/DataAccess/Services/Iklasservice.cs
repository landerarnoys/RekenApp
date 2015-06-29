using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Services
{
    public interface Iklasservice
    {
        //List<Klas> Haalklassenvanschoolop(int schoolID);
        //List<LeerkrachtSchoolKlas> Haalklassenvanschoolopmetleerkrachten(int schoolID);
        List<LeerkrachtSchoolKlas> Haalklassenvanschoolopmetleerkrachten(int schoolID);

        //Ophalen leerkrachten voor leerkrachtenview
        List<LeerkrachtSchoolKlas> Haalleerkrachtenop(int gebruikersid);

        List<LeerkrachtSchoolKlas> Haalklassenop(int schoolid);

        LeerkrachtSchoolKlas getLeerkrachtSchoolKlas(int id);

        void removeClass(LeerkrachtSchoolKlas slk);

        List<Klas> getKlasById(int id);

        void updateKlas(Klas klas);

        Leerkracht getLeerkrachtById(int id);

        void updateLeerkracht(Leerkracht teEditerenLk);

        void deleteLeerkracht(Leerkracht leerkracht);
    }
}
