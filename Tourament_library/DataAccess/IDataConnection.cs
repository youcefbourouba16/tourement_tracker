using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.Models;


namespace Tourament_library.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel createPrize(PrizeModel model);

        person ceatePeson(person person1);
        teamModel createTeam(teamModel team);
         void createTourament(tourement_Model tr);
        /// todo-  notice that we changed create tourament to void

        List<person> getPersonAll();
        List<teamModel> getTeamAll();

        



    }
}
