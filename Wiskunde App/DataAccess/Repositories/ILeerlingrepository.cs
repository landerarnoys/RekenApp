using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Repositories
{
    public interface ILeerlingrepository : IGenericRepository<Leerling>
    {
        List<Leerling> Haalleerlingenschoolop(int LeerlingschoolID);
    }
}
