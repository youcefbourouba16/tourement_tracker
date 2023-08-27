using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.Models;

namespace TrackerUi
{
    public interface IteamRequester
    {
        void teamComplete(teamModel model);
    }
}
