    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.Models;
using Tourament_library.DataAccess.Convert;
using System.Reflection;

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
                                        PrizeFile);
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
            

            
            touraments.saveTouramentFile(touramentFile,Matchupfile,MatchupEntriesFile,roundFile);
            
        }
        public void createMatchup(MatchupModel Matchup)
        {
            List<MatchupModel> Matchups = Matchupfile.getFullpath().loadFile().
                convertToMatchuplList(MatchupEntriesFile,teamFile,peopleFile);
            int currentID;
            try
            {
                currentID = Matchups.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            // add the new record (id+1)
            Matchup.id = currentID;

            Matchups.Add(Matchup);



            Matchups.saveMatchupList(Matchupfile);

        }
        public void createMatchupEntries(MatchupEntrieModel MatchupEntrie)
        {
            List<MatchupEntrieModel> MatchupEnries = Matchupfile.getFullpath().loadFile().
                convertToMatchEntryModelList(teamFile,Matchupfile,peopleFile);
            int currentID;
            try
            {
                currentID = MatchupEnries.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            // add the new record (id+1)
            MatchupEntrie.id = currentID;

            MatchupEnries.Add(MatchupEntrie);



            MatchupEnries.saveEntriesList(Matchupfile);

        }


    }
    
}
