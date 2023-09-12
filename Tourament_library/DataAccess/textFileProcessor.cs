using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Tourament_library.Models;
using Tourament_library.DataAccess;
namespace Tourament_library.DataAccess.Convert
{
    // * load the text file
    // * convert the text to prizes=list<prize model>
    // find the max ID
    // add the new record (id+1)
    //convert convert prizes to list<string>
    // save the list as text
    public static class textFileProcessor
    {
        

        public static string getFullpath(this string fileName)//prizeModel.csv //this. help to make it 
                                                              //as extension so when we call it (getFullpath.String)
        {
            // Get the base directory from the configuration
            string baseDirectory = ConfigurationManager.AppSettings["filePath"];

            // Combine the base directory, directoryName, and fileName
            string fullPath = Path.Combine(baseDirectory, "Tourament Treacker by youcef", fileName);

            // Create the directory if it doesn't exist
            string directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return fullPath;
        }

        ///// take the full file path and load that string
        public static List<string> loadFile(this string file) {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }
        public static List<person> convertToPeopleModel(this List<string> lines)
        {
            List<person> output = new List<person>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                person p = new person();
                p.id = int.Parse(parts[0]);
                p.name = parts[1];
                p.lastName = parts[2];
                p.email = parts[3];
                p.phone = parts[4];
                output.Add(p);


            }
            return output;


        }
        public static List<PrizeModel> convertToPrizeModel(this List<string> lines) {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach (string line in lines) {
                string[] parts = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.id = int.Parse(parts[0]);
                p.placeName = parts[1];
                p.prizeAmount = int.Parse(parts[2]);
                p.prizePercentage = float.Parse(parts[3]);
                p.placeNumber = int.Parse(parts[4]);
                output.Add(p);


            }
            return output;
            
            
        }
        /// <summary>
        /// it convert the model into a list of string than it add element of the model
        /// to the list string with "," in bett
        /// </summary>
        /// <param name="List of models"></param>
        /// <param name="file Name"></param>
        public static void savePrizeToTextfile(this List<PrizeModel> Models, string fileName) {

            List<string> lines = new List<string>();

            foreach (PrizeModel p in Models) {

                lines.Add($"{p.id},{p.placeName},{p.prizeAmount},{p.prizePercentage},{p.placeNumber}");

            }
            string s = fileName.getFullpath();

            File.WriteAllLines(fileName.getFullpath(), lines);



        }
        public static void savePeoplesToTextfile(this List<person> persons, string fileName)
        {

            List<string> lines = new List<string>();

            foreach (person p in persons)
            {

                lines.Add($"{p.id},{p.name},{p.lastName},{p.email},{p.phone}");

            }
            string s = fileName.getFullpath();

            File.WriteAllLines(fileName.getFullpath(), lines);



        }
        public static void saveToteamFile(this List<teamModel> teams, string fileName)
        {

            List<string> lines = new List<string>();
           
            

            foreach (teamModel p in teams)
            {
                

                lines.Add($"{p.id} , {p.teamName} , {convertTeamMemberToString(p.team_member)}");



            }
            string s = fileName.getFullpath();

            File.WriteAllLines(fileName.getFullpath(), lines);



        }
        public static void saveTouramentFile(
            this List<tourement_Model> touraments, 
            string touramentFile,
            string matchupFile,
            string matchupENtriesFIles,
            string roundFile)
        {
            List<string> lines = new List<string>(); /*touramentFile.getFullpath().loadFile();*/
            foreach (tourement_Model tr in touraments)
            {
                lines.Add($"{tr.id} , {tr.TourramentName} ," +
                    $"{tr.EntryFee}," +
                    $" {convertTeamEntriesListToString(tr.EnteredTeams)}," +
                    $"{convertTourPrizesListToString(tr.Prizes)},{convertTourRoumdListToString(tr.round)}");
            }

            File.WriteAllLines(touramentFile.getFullpath(), lines);
        }
        public static void saveMatchupList(this List<MatchupModel> Matchups, string MatchupFile)
        {
            List<string> lines = MatchupFile.getFullpath().loadFile();
            foreach (MatchupModel tr in Matchups)
            {
                if (tr.Winner!=null)
                {
                    lines.Add($"{tr.id} , {convertTeamMatchupEntriesListToString(tr.Entries)} ," +
                    $"{tr.Winner}," +
                    $" {(tr.matchRound)}");
                }
                else
                {
                    lines.Add($"{tr.id} , {convertTeamMatchupEntriesListToString(tr.Entries)} ," +
                    "0," +
                    $" {(tr.matchRound)}");
                }
                
            }
            
            File.WriteAllLines(MatchupFile.getFullpath(), lines);
        }
        public static void saveEntriesList(this List<MatchupEntrieModel> Entries, string matchupEntriesFile)
        {
            List<string> lines = matchupEntriesFile.getFullpath().loadFile();
            string output="";
            foreach (MatchupEntrieModel tr in Entries)
            {
                output += $"{tr.id},";
                
                if (tr.teamCompreting!=null)
                {
                    output+=$" {tr.teamCompreting.id},";
                }else output+=$" ,";
                if (tr.score != null)
                {
                    output += $"{tr.score},";
                }else output += $" ,";

                if (tr.matchupParent != null)
                {
                    output += $"{(tr.matchupParent.id)},";
                }else output += $" ,"; 

                lines.Add(output);
                output = "";

            }
            
            File.WriteAllLines(matchupEntriesFile.getFullpath(), lines);
        }
        public static void saveRoundsFile(
            this tourement_Model tourament,
            string matchupFile,
            string matchupEntriesFile,
            string roundFile,
            string teamFile,
            string peopleFile
            )
        {
            List<MatchupModel> matchups = matchupFile.getFullpath().loadFile().convertToMatchuplList(matchupEntriesFile, teamFile, peopleFile);
            List<MatchupEntrieModel> entries = matchupEntriesFile.getFullpath().loadFile().convertToMatchEntryModelList(teamFile, matchupFile, peopleFile);
            List<MatchupModel> lines = roundFile.getFullpath().loadFile().convertToRoundList(teamFile, matchupFile, peopleFile);
            List<string> strings = roundFile.getFullpath().loadFile();
            string output = "";
            int matchupListID = getIDMatchupList(matchups);
            int entriesListID = getIDEnrtyList(entries);
            List<MatchupModel> newMatchupsList = new List<MatchupModel>();
            List<MatchupEntrieModel> newEntriesList = new List<MatchupEntrieModel>();
            foreach (List<MatchupModel> list in tourament.round)
            {
                
                

                foreach (MatchupModel e in list)
                {
                    e.id = matchupListID;
                    matchupListID++;
                    output += $"{e.id}^";
                    newMatchupsList.Add(e);
                    foreach (MatchupEntrieModel entry in e.Entries)
                    {
                         entry.id = entriesListID;
                        entriesListID++;
                        
                         newEntriesList.Add(entry);
                    }
                    lines.Add(e);
                }
            }

            //string str = output.Substring(0, output.Length - 1);
            //strings.Add(str);
            string str = convertTourRoumdListToString(tourament.round);
            strings.Add(str);
            saveEntriesList(newEntriesList, matchupEntriesFile);
            saveMatchupList(newMatchupsList, matchupFile);
            File.WriteAllLines(roundFile.getFullpath(), strings);
        }
        public static string convertTourRoumdListToString(List<List<MatchupModel>> rounds)
        {
            //(round id ^ id ^ id | id ^ id ^ id..)
            string output = "";
            if (rounds.Count == 0)
            {
                return output;

            }
            foreach (List<MatchupModel> round in rounds)
            {
                foreach (MatchupModel model in round)
                {
                    if (model!=null)
                    {
                        output += $"{model.id}^";
                    }else output += $"^";

                }
                output += "|";
            }
            string str = output.Substring(0, output.Length - 1);
            return str;
            /// todo- this might be faulse(convertTourRoumdListToString) fonction
        }

        public static int getIDMatchupList(List<MatchupModel> matchups)
        {
            int currentID;
            try
            {
                currentID = matchups.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            return currentID;
        }
        public static int getIDRound(List<MatchupModel> matchups)
        {
            int currentID;
            try
            {
                currentID = matchups.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            return currentID;
        }
        public static int getIDEnrtyList(List<MatchupEntrieModel> matchups)
        {
            int currentID;
            try
            {
                currentID = matchups.OrderByDescending(x => x.id).First().id + 1;
            }
            catch (Exception)
            {

                currentID = 1;
            }
            return currentID;
        }
        public static List<MatchupModel> convertToRoundList(
            this List<string> lines,
            string teamFile,
            string MatchupFile,
            string peopleFile
            )
        {
            //roundsID,matchupId^matchupId^matchupId|matchupId^matchupId^matchupId
            List<MatchupModel> output = new List<MatchupModel>();
            List<MatchupModel> matchups = MatchupFile.getFullpath().loadFile().convertToMatchuplList(MatchupFile, teamFile, peopleFile);
            if (matchups.Count == 0)
            {
                return output;
            }
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                MatchupModel e = new MatchupModel();
                string[] parts1 = parts[0].Split('|');
                foreach (var line1 in parts1)
                {
                    string[] matchupsID = line1.Split('^');
                    foreach (var b in matchupsID)
                    {
                        if (b!="")
                        {
                            e = matchups.Where(x => x.id == int.Parse(b)).First();
                        }
                        
                    }
                    output.Add(e);
                }
            }
            return output;
        }
        public static List<MatchupEntrieModel> convertToMatchEntryModelList(
            this List<string> lines,
            string teamFile,
            string MatchupFile,
            string peopleFile)
        {
            List<MatchupEntrieModel> output = new List<MatchupEntrieModel>();
            List<teamModel> teams = teamFile.getFullpath().loadFile().convertToteamModelList(peopleFile);
            List<MatchupModel> matchups = MatchupFile.getFullpath().loadFile().convertToMatchuplList(MatchupFile, teamFile, peopleFile);
            if (matchups.Count == 0)
            {
                return output;
            }
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                MatchupEntrieModel p = new MatchupEntrieModel();
                p.id = int.Parse(parts[0]);
                if (parts[1]==" ")
                {
                    p.teamCompreting = null;
                }
                else p.teamCompreting = teams.Where(x => x.id == int.Parse(parts[1])).First();
                p.score = double.Parse(parts[2]);
                if (parts[3] == " ")
                {
                    p.matchupParent = null;
                }
                else p.matchupParent = matchups.Where(x => x.id == int.Parse(parts[3])).First(); 
                output.Add(p);
            }
            return output;
        }
        public static List<MatchupModel> convertToMatchuplList(
            this List<string> lines, 
            string MatchentrieFile,
            string teamFile,
            string peopleFile)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            // todo-- i have to add entries inserted in matchup.entry 
            List<teamModel> teams = teamFile.getFullpath().loadFile().convertToteamModelList(peopleFile);
            
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                MatchupModel p = new MatchupModel();
                p.id = int.Parse(parts[0]);
                if (parts[2] == "0")
                {
                    p.Winner = null;
                }
                else p.Winner = teams.Where(x => x.id == int.Parse(parts[2])).First();
                
                
                p.matchRound = int.Parse(parts[3]);
                output.Add(p);
            }
            return output;
        }


        public static string convertTeamMemberToString (List<person> persons){
            string output = "";
            if (persons.Count==0)
            {
                return output;

            }
            foreach (var person in persons)
            {
                output += $"{person.id} |";
            }
            string str = output.Substring(0, output.Length - 1);
            return str;

        }
        public static string convertTeamEntriesListToString(List<teamModel> teams)
        {
            string output = "";
            if (teams.Count == 0)
            {
                return output;

            }
            foreach (var team in teams)
            {
                output += $"{team.id}^";
            }
            string str = output.Substring(0, output.Length - 1);
            return str;

        }
        public static string convertTeamMatchupEntriesListToString(List<MatchupEntrieModel> teams)
        {
            string output = "";
            if (teams.Count == 0)
            {
                return output;

            }
            foreach (var team in teams)
            {
                output += $"{team.id}^";
            }
            string str = output.Substring(0, output.Length - 1);
            return str;

        }
        public static string convertTourPrizesListToString(List<PrizeModel> prizes)
        {
            string output = "";
            if (prizes.Count == 0)
            {
                return output;

            }
            foreach (var prize in prizes)
            {
                output += $"{prize.id}*";
            }
            string str = output.Substring(0, output.Length - 1);
            return str;
        }
        
        


        public static List<teamModel> convertToteamModelList(this List<string> lines,string peopleFIleName)
        {
            /// id,teamName,personID|personID|personID....
            /// 0,0,fs barcelona,0|1|2|4

            List<teamModel> output = new List<teamModel>();
            List<person> persons = peopleFIleName.getFullpath().loadFile().convertToPeopleModel();
            if (persons.Count == 0)
            {
                return output;
            }
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                teamModel p = new teamModel();
                p.id = int.Parse(parts[0]);
                p.teamName = parts[1];
                
                /// hadi bch ndiru list id f string 
                string[] personIds = parts[2].Split('|');
                foreach (var id in personIds)
                {
                    if (id!="")
                    {
                        p.team_member.Add(persons.Where(x => x.id == int.Parse(id)).First());
                        
                    }
                    

                }
                output.Add(p);



            }
            return output;
        

        }
        public static List<tourement_Model> convertToTouramentModelList(
            this List<string> lines, 
            string teamfile,
            string peopleFile,
            string prizeFile,
            string matchupFile,
            string matchupEntryFile
            )
        {

            List<tourement_Model> trs = new List<tourement_Model>();
            List<teamModel> teams = teamfile.getFullpath().loadFile().convertToteamModelList(peopleFile);
            List<PrizeModel> prizes = prizeFile.getFullpath().loadFile().convertToPrizeModel();
            List<MatchupModel> matchups=matchupFile.getFullpath().loadFile().convertToMatchuplList(matchupEntryFile,teamfile,peopleFile);



            /// id,touramentName,fee,(team1^team2^team3),(prize*prize1*prize2), (round id^id^id|id^id^id..)..
            foreach (string line in lines)
            {
                string[] trParts = line.Split(',');
                tourement_Model p = new tourement_Model();
                List<MatchupModel> e = new List<MatchupModel>();
                p.id = int.Parse(trParts[0]);
                p.TourramentName = trParts[1];
                p.EntryFee = double.Parse(trParts[2]);
                string[] tmParts = trParts[3].Split('^');
                foreach (var id in tmParts)
                {
                    if (id!="")
                    {
                        p.EnteredTeams.Add(teams.Where(x => x.id == int.Parse(id)).First());
                    }

                }
                string[] tpPart = trParts[4].Split('*');
                foreach (var id in tpPart) 
                {
                    if (id != "")
                    {
                        p.Prizes.Add(prizes.Where(x => x.id == int.Parse(id)).First());
                    }
                }
                List<MatchupModel> mathups = new List<MatchupModel>();
                List<List<MatchupModel>> rounds = new List<List<MatchupModel>>();

                string[] RdPart = trParts[5].Split('|');
                foreach (var id in RdPart)
                {
                    
                    string[] MatchupPart = id.Split('^');
                    foreach (var mt in MatchupPart)
                    {
                        if (mt != "")
                        {
                            mathups.Add(matchups.Where(x => x.id == int.Parse(mt)).First());
                        }
                        else mathups.Add(null);
                    }
                    rounds.Add(mathups);
                    mathups = new List<MatchupModel>();


                }
                p.round = rounds;
                trs.Add(p);
            }
            return trs;

        }
        












    }
}
