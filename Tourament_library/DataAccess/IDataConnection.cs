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

        List<person> getPersonAll();
        //ff
        teamModel createTeam(teamModel team);
        



    }
}
