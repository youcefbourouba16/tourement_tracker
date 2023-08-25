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




        // todo -wire up text files
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

        
        
        public teamModel createTeam(teamModel team)
        {
            List<teamModel> teams = teamFile.getFullpath().loadFile().convertToteamModel(teamFile);
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
    }
    
}
