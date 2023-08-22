using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourament_library.Models
{
    public class MatchupEntrieModel
    {
        /// <summary>
        /// the 2 team compeing
        /// </summary>
        public teamModel teamCompreteting { get; set; }
        public double score { get; set; }
        /// <summary>
        /// the previos match information 
        /// </summary>
        public MatchupModel matchupParent { get; set; }

        /// <summary>
        /// constracter for score and matche entries and match parent
        /// </summary>
        /// <param name="teamCompreteting"></param>
        /// <param name="score"></param>
        /// <param name="matchupParent"></param>
        public MatchupEntrieModel(teamModel teamCompreteting, double score, MatchupModel matchupParent)
        {
            this.teamCompreteting = teamCompreteting;
            this.score = score;
            this.matchupParent = matchupParent;
        }
    }
}
