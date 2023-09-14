using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourament_library.Models
{
    public class tourement_Model
    {
        public int id;
        public string TouramentName { get; set; }
        public double EntryFee;
        public List<teamModel> EnteredTeams = new List<teamModel>();
        public List<PrizeModel> Prizes = new List<PrizeModel>();
        public List<List<MatchupModel>> round { get; set; } = new List<List<MatchupModel>>();

        public tourement_Model(string touramentName, 
                                double entryFee,
                                List<teamModel> enteredTeams,
                                List<PrizeModel> prizes
                                )
        {
            TouramentName = touramentName;
            EntryFee = entryFee;
            EnteredTeams = enteredTeams;
            Prizes = prizes;
            
        }

        
        public tourement_Model() { }
    }
}
