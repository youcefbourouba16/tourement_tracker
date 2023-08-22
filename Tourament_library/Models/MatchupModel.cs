using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourament_library.Models
{
    public class MatchupModel{
        public List<MatchupEntrieModel> Entries { get; set; } = new List<MatchupEntrieModel>();
        public teamModel Winner { get; set; }
        public int matchRound { get; set; }

    }
}
