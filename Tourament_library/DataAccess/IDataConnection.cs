﻿using System;
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

        List<person> getPersonAll();
        List<teamModel> getTeamAll();

        List<tourement_Model> getTourAll();
        void UpdateTourament(tourement_Model tr);
        void touramentComplete(tourement_Model tr,int x);






    }
}
