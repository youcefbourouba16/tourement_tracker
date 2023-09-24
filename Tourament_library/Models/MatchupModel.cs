using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourament_library.Models
{
    public class MatchupModel{
        public MatchupModel()
        {
            
        }
        public int id { get; set; }
        public List<MatchupEntrieModel> Entries { get; set; } = new List<MatchupEntrieModel>();
        public teamModel Winner { get; set; }
        public int winnerID { get; set; }
        public int MatchupRound { get; set; }
        public string fullNamesEntries
        {
            get
            {
                string s = "";

                int count = 0;
                foreach (MatchupEntrieModel entry in Entries)
                {
                    count++;
                    if (MatchupRound == 1 && entry.teamCompreting == null)
                    {
                        s += " bye(neutral)";
                        break;
                    }
                    else if (MatchupRound > 1 && entry.teamCompreting == null)
                    {
                        s += " not yet define ";
                        break;
                    }
                    if (count == 1)
                    {
                        s += $"{entry.teamCompreting.teamName} Vs ";
                    }
                    else s += $"{entry.teamCompreting.teamName}";
                }
                return s;

            }



        }


    }
}
