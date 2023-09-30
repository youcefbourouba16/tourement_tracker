    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.Models;
using Tourament_library.DataAccess.Convert;
using System.Reflection;
using System.Xml;
using System.IO;

namespace Tourament_library.DataAccess
{
    public class textConnection : IDataConnection
    {
        private const string PrizeFile = "prizeModel.csv";
        private const string peopleFile = "peopleFile.csv";
        private const string teamFile = "teamFile.csv";
        private const string touramentFile = "TouramentFile.csv";
        private const string Matchupfile = "MatchupFile.csv";
        private const string MatchupEntriesFile = "MatchupEntriesFile.csv";
        private const string roundFile = "roundFile.csv";
        public PrizeModel createPrize(PrizeModel model)
        {
            //load the text file
            //convert the text to prizes=list<prize model>
            List<PrizeModel> prizes=  PrizeFile.getFullpath().loadFile().convertToPrizeModel();

            // find the max ID
            int currentID;
            try
            {
                currentID = prizes.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception )
            {

                currentID = 1;
            }
            // add the new record (id+1)
            model.id = currentID;
            prizes.Add(model);

            prizes.savePrizeToTextfile(PrizeFile);
            return model;


            //convert convert prizes to list<string>
            // save the list as text
            // get the full path string

        }
        
        public person ceatePeson(person person1)
        {

            List<person> persons = peopleFile.getFullpath().loadFile().convertToPeopleModel();

            // find the max ID
            int currentID;
            try
            {
                currentID = persons.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            // add the new record (id+1)
            person1.id = currentID;
            persons.Add(person1);

            persons.savePeoplesToTextfile(peopleFile);
            return person1;
        }

        public List<person> getPersonAll()
        {
            return peopleFile.getFullpath().loadFile().convertToPeopleModel();
        }
        public List<teamModel> getTeamAll()
        {
            return teamFile.getFullpath().loadFile().convertToteamModelList(peopleFile);
        }



        public teamModel createTeam(teamModel team)
        {
            List<teamModel> teams = teamFile.getFullpath().loadFile().convertToteamModelList(peopleFile);
            int currentID;
            try
            {
                currentID = teams.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            // add the new record (id+1)
            team.id = currentID;
            teams.Add(team);

            teams.saveToteamFile(teamFile);
            return team;
        }
        
        
        public void createTourament(tourement_Model tr)
        {
            List<tourement_Model> touraments = touramentFile.getFullpath().loadFile().
                convertToTouramentModelList(teamFile,
                                        peopleFile,
                                        PrizeFile,
                                        Matchupfile,
                                        MatchupEntriesFile);
            int currentID;
            try
            {
                currentID = touraments.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            // add the new record (id+1)
            tr.id = currentID;
            touraments.Add(tr);
            

               
                        
                    
            touraments.saveTouramentFile(touramentFile,Matchupfile,MatchupEntriesFile,teamFile,peopleFile);
            
        }

        public List<tourement_Model> getTourAll()
        {
            return touramentFile.getFullpath().loadFile().convertToTouramentModelList(teamFile, peopleFile, PrizeFile, Matchupfile, MatchupEntriesFile);
        }

        public void UpdateTourament(tourement_Model tr)
        {

            /// id,name,fee,Entrie,rounds,acitveStatus
            ///(entry) id,teamcompetin.Id,score,matchupParent
            ///(matchup) id,matchupEntries,winner,matchupRound
            List<string> touraments = touramentFile.getFullpath().loadFile();
            List<string> entries = MatchupEntriesFile.getFullpath().loadFile();
            List<string> matchups = Matchupfile.getFullpath().loadFile();
            List<MatchupModel> AllmatchupOftour = new List<MatchupModel>();
            MatchupModel matchup = new MatchupModel();
            List<MatchupEntrieModel> AllEntriesOftour = new List<MatchupEntrieModel>();
            MatchupEntrieModel entry = new MatchupEntrieModel();
            foreach (List<MatchupModel> MatchupList in tr.round)
            {
                foreach (MatchupModel matchup1 in MatchupList)
                {
                    AllmatchupOftour.Add(matchup1);
                    matchup1.winnerID = matchup1.Winner.id;
                    foreach (MatchupEntrieModel item in matchup1.Entries)
                    {
                        AllEntriesOftour.Add(item);
                    }
                }
            }

            string output= "";
            int indexTour=0;
            foreach (MatchupEntrieModel entr in AllEntriesOftour)
            {
                
                for (int i = 0; i < entries.Count; i++)
                {

                    string[] c = entries[i].Split(',');
                    if (entr.id== int.Parse(c[0]))
                    {
                        entries[i] = $"{entr.id},{entr.TeamCompetingID},{entr.score},";
                    }
                    if (entr.matchupParent!=null)
                    {
                        entr.ParentMatchupID = entr.matchupParent.id;
                        entries[i] += $"{entr.matchupParent.id}";
                    }
                }
            }
            foreach (MatchupModel mat in AllmatchupOftour)
            {
                if (mat.Winner!=null)
                {
                    mat.winnerID = mat.Winner.id;
                }
                for (int i = 0; i < matchups.Count; i++)
                {
                    string[] k = matchups[i].Split(',');
                    if (mat.id == int.Parse(k[0]))
                    {
                        matchups[i] = $"{mat.id},{textFileProcessor.convertTeamMatchupEntriesListToString(mat.Entries)}," +
                            $"{mat.winnerID},{mat.MatchupRound}";
                    }
                }
            }
            /// update tourament
            /// id,touramentName,fee,(team1^team2^team3),(prize*prize1*prize2), (round id^id^id|id^id^id..)..
            output += $"{tr.id}," +
                $"{tr.TouramentName}," +
                $"{tr.EntryFee}," +
                $"{textFileProcessor.convertTeamEntriesListToString(tr.EnteredTeams)}," +
                $"{textFileProcessor.convertTourPrizesListToString(tr.Prizes)}," +
                $"{textFileProcessor.convertTourRoumdListToString(tr.round)}," +
                $"{tr.Active}";
            touraments[indexTour] = output;

            File.WriteAllLines(MatchupEntriesFile.getFullpath(), entries);
            File.WriteAllLines(Matchupfile.getFullpath(), matchups);
            File.WriteAllLines(touramentFile.getFullpath(), touraments);



        }

        public void touramentComplete(tourement_Model tr,int x)
        {
            if (x==0)
            {
                List<string> touraments = touramentFile.getFullpath().loadFile();
                int i = 0;
                tr.Active = 0;
                int index=0;
                foreach (string item in touraments)
                {
                    string[] c = item.Split(',');
                    if (int.Parse(c[0]) == tr.id)
                    {
                        index = i; break;
                    }
                    i++;
                }
                touraments.RemoveAt(index);
                File.WriteAllLines(touramentFile.getFullpath(), touraments);

            }
            if (x==2)
            {
                tr.Active = 2;
                UpdateTourament(tr);
            }
            
        }


    }
   
    
}
