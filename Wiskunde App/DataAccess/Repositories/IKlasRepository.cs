using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Repositories
{
    public interface IKlasRepository : IGenericRepository<Klas>
    {
        IEnumerable<Klas> Haalklassenopvanbepaaldeschool(int Gebruikersid);

        //Testmethode tussentabel
        List<LeerkrachtSchoolKlas> Toonalleklassenmetleerkrachten(int gebruikersnaam);

        List<LeerkrachtSchoolKlas> Toonalleleerkrachten(int gebruikersschoolID);

        List<LeerkrachtSchoolKlas> Toonalleklassen(int schoolID);

        void deleteClass(LeerkrachtSchoolKlas leerkrachtSchoolKlas);

        List<Klas> getKlasById(int klasId);

        void updateKlas(Klas klas);

        Leerkracht getLeerkrachtById(int id);

        void updateLeerkracht(Leerkracht teEditerenLk);

        void deleteLeerkracht(Leerkracht leerkracht);
    }
}
