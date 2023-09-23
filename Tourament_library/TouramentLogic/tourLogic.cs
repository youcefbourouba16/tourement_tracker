using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.Models;

namespace Tourament_library.TouramentLogic
{
    //static means we can use it in main code (form)
    public static class tourLogic
    {
        // order the list randomly 
        // teams should be 2 or more
        //if it's number team count id even can divie by 2 do not add byes ==>else ad one byes in first round
        // create rounds
        public static void CreateRounds(tourement_Model model)
        {
            List<teamModel> randomazeTeam = RandomizTeamModel(model.EnteredTeams);
            int rounds = NumberOfRound(randomazeTeam);
            int byess = NumberOfbyess(randomazeTeam.Count);

            model.round.Add(createFirstRound(byess, randomazeTeam));
            createOtherRounds(model, rounds);





        }
        public static void createOtherRounds(tourement_Model model, int rounds)
        {
            int round = 2;
            List<MatchupModel> PreviousRound = model.round[0];
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();
            while (round <= rounds)
            {
                foreach (MatchupModel match in PreviousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntrieModel { matchupParent = match });
                    if (currMatchup.Entries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new MatchupModel();


                    }



                }
                model.round.Add(currRound);
                PreviousRound = currRound;
                currRound = new List<MatchupModel>();
                round += 1;
            }

        }

        public static List<MatchupModel> createFirstRound(int byess, List<teamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();
            foreach (teamModel team in teams)
            {
                if (byess >= 1)
                {
                    curr.Entries.Add(new MatchupEntrieModel { teamCompreting = team, TeamCompetingID = team.id });
                    curr.Entries.Add(new MatchupEntrieModel { teamCompreting = null, TeamCompetingID = 0 });
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();
                    byess -= 1;

                }
                else
                {
                    curr.Entries.Add(new MatchupEntrieModel { teamCompreting = team });
                    if (curr.Entries.Count > 1)
                    {
                        curr.MatchupRound = 1;
                        output.Add(curr);
                        curr = new MatchupModel();

                    }
                }


            }
            return output;
        }
        public static int NumberOfbyess(int numbrtOfteams)
        {
            int x = 2;
            while (x < numbrtOfteams)
            {
                x *= 2;
            }
            return x - numbrtOfteams;
        }

        public static int NumberOfRound(List<teamModel> teams)
        {

            int count = teams.Count;
            int round = 0;
            int byes = 0;
            //// note that the count number should be grater than 1 (count >1)
            do
            {
                if (count % 2 == 0)
                {
                    round++;
                    count /= 2;
                }
                else
                {
                    count++;
                    round++;
                    count /= 2;
                    byes++;
                }

            } while (count > 1);
            return round;
        }
        public static List<teamModel> RandomizTeamModel(List<teamModel> model)
        {
            return model.OrderBy(a => Guid.NewGuid()).ToList();
        }
        public static List<MatchupEntrieModel> RandomizTeamModel(List<MatchupEntrieModel> model)
        {
            return model.OrderBy(a => Guid.NewGuid()).ToList();
        }
        public static tourement_Model winnerToNextMatcup(tourement_Model tr,int round)
        {
            List<MatchupEntrieModel> winningTeams = new List<MatchupEntrieModel>();
            MatchupEntrieModel tempEntry = new MatchupEntrieModel();
            List<MatchupModel> tempNewMatchups = new List<MatchupModel>();
            MatchupModel tempNewMatchup = new MatchupModel();
            ///add new entries list
            int count=1;
            foreach (MatchupModel matchup in tr.round[round-1])
            {
                if (matchup.Winner != null)
                {

                    if (count==1 || count%2==0)
                    {
                        foreach (MatchupEntrieModel item in matchup.Entries)
                        {
                            if (item.teamCompreting == matchup.Winner)
                            {
                                
                                tempEntry.teamCompreting = item.teamCompreting;
                                tempEntry.score = 0;
                                tempEntry.matchupParent = matchup;
                                tempEntry.ParentMatchupID = matchup.id;
                                tempEntry.TeamCompetingID = item.TeamCompetingID;
                                //int index = matchup.Entries.IndexOf(item);
                                //tempEntry = matchup.Entries[index];
                                //tempEntry.score = 0;
                                //tempEntry.matchupParent = matchup;
                                //tempEntry.ParentMatchupID = matchup.id;

                            }
                        }
                        winningTeams.Add(tempEntry);
                        tempEntry = new MatchupEntrieModel();
                    }
                    
                }
                if (count % 2 == 0)
                {
                    tempNewMatchup.MatchupRound = round+1;
                    tempNewMatchup.Entries = winningTeams;
                    winningTeams = new List<MatchupEntrieModel>();
                    tempNewMatchups.Add(tempNewMatchup);
                    tempNewMatchup = new MatchupModel();
                    count=1;
                }
                else count++;
                

            }
            /// to get the original id for the matchup and put it  in the previeus one to keep  track of original tourament
            foreach (MatchupModel match in tr.round[round])
            {
                for (int i = 0; i < tempNewMatchups.Count; i++)
                {
                    tempNewMatchups[i].id = match.id;
                    for (int j = 0; j < match.Entries.Count; j++)
                    {
                        if (tempNewMatchups[i].Entries.Count == 2)
                        {
                            tempNewMatchups[i].Entries[j].id = match.Entries[j].id;
                        }
                        else break;
                        
                        
                    }
                    break;
                }
                
            }
            tr.round[round] = tempNewMatchups;
            
            return tr;
        }

    }
}