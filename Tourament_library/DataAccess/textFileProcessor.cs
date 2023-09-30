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
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

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
            string teamFile,
            string peopleFile)
        {
            List<string> lines = new List<string>(); /*touramentFile.getFullpath().loadFile();*/
            List<MatchupEntrieModel> ENtries = new List<MatchupEntrieModel>();
            List<MatchupModel> MAtchups = new List<MatchupModel>();
            foreach (tourement_Model tr in touraments)
            {
                foreach (List<MatchupModel> matchups in tr.round)
                {
                    foreach (MatchupModel match in matchups)
                    {
                        MAtchups.Add(match);
                        
                        
                            foreach (MatchupEntrieModel entry in match.Entries)
                            {
                                if (entry.teamCompreting!=null)
                                {
                                    entry.TeamCompetingID = entry.teamCompreting.id;
                                }else entry.TeamCompetingID = 0;

                                ENtries.Add(entry);
                            }
                           
                            
                        
                    }
                   
                }
            }
            
            ENtries.saveEntriesList( matchupENtriesFIles, teamFile, peopleFile, matchupFile);
            MAtchups.saveMatchupList(matchupFile, matchupENtriesFIles, teamFile, peopleFile);
            foreach (tourement_Model tr in touraments)
            {
                /// id,name,fee,Entrie,rounds,acitveStatus
                lines.Add($"{tr.id} , {tr.TouramentName} ," +
                    $"{tr.EntryFee}," +
                    $" {convertTeamEntriesListToString(tr.EnteredTeams)}," +
                    $"{convertTourPrizesListToString(tr.Prizes)},{convertTourRoumdListToString(tr.round)},{tr.Active}");
            }

            File.WriteAllLines(touramentFile.getFullpath(), lines);
        }
        public static void saveMatchupList(this List<MatchupModel> Matchups, string MatchupFile,string matchupEntriesFile,string teamFile,string peopleFile)
        {
            List<string> lines = MatchupFile.getFullpath().loadFile();
            List<MatchupModel> MatchupList = MatchupFile.getFullpath().loadFile().convertToMatchuplList(matchupEntriesFile, MatchupFile, teamFile, peopleFile);
            // id,matchupEntries,winner,matchupRound
            int matchupListID = getIDMatchupList(MatchupList);
            
            foreach (MatchupModel tr in Matchups)
            {
                tr.id = matchupListID;
                matchupListID++;
                if (tr.Winner!=null)
                {
                    lines.Add($"{tr.id} , {convertTeamMatchupEntriesListToString(tr.Entries)} ," +
                    $"{tr.winnerID}," +
                    $" {(tr.MatchupRound)}");
                }
                else
                {
                    lines.Add($"{tr.id} , {convertTeamMatchupEntriesListToString(tr.Entries)} ," +
                    "0," +
                    $" {(tr.MatchupRound)}");
                }
                
            }
            
            File.WriteAllLines(MatchupFile.getFullpath(), lines);
        }
        public static void saveEntriesList(this List<MatchupEntrieModel> Entries, string matchupEntriesFile,string teamFile,string peopleFile,string MatchipFile)
        {
            // id,teamcompetin.Id,score,matchupParent
            List<string> lines = matchupEntriesFile.getFullpath().loadFile();
            List<MatchupEntrieModel> EntriesLIst = lines.convertToMatchEntryModelList(teamFile, MatchipFile, peopleFile, matchupEntriesFile); ;
            int entriesListID = getIDEnrtyList(EntriesLIst);
            string output="";
            foreach (MatchupEntrieModel tr in Entries)
            {
                tr.id = entriesListID;
                entriesListID++;
                output += $"{tr.id},";
                
                if (tr.teamCompreting!=null)
                {
                    output+=$"{tr.teamCompreting.id},";
                }else output+=$"0,";
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
        public static string convertTourRoumdListToString(List<List<MatchupModel>> rounds)
        {
            //(round Matchup id ^ id ^ id | id ^ id ^ id..)
            string output = "";
            if (rounds.Count == 0)
            {
                return output;

            }
            foreach (List<MatchupModel> round in rounds)
            {
                foreach (MatchupModel model in round)
                {
                    if (model.id!=null)
                    {
                        output += $"{model.id}^";
                    }else output += $"^";

                }
                string s = output.Substring(0, output.Length - 1);
                output = s;
                output += "|";
            }
            
            string str = output.Substring(0, output.Length - 1);
            return str;
           
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
        
        public static List<MatchupEntrieModel> convertToMatchEntryModelList(
            this List<string> lines,
            string teamFile,
            string MatchupFile,
            string peopleFile,
            string MatchupEntrisFile)
        {
            // id,teamcompetin.Id,score,matchupParent
            List<MatchupEntrieModel> output = new List<MatchupEntrieModel>();
            List<teamModel> teams = teamFile.getFullpath().loadFile().convertToteamModelList(peopleFile);
            
            if (teams.Count == 0)
            {
                return output;
            }
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                MatchupEntrieModel p = new MatchupEntrieModel();
                p.id = int.Parse(parts[0]);
                if (parts[1]== "0")
                {
                    p.teamCompreting = null;
                    p.TeamCompetingID = 0;
                }
                else {
                         p.teamCompreting = teams.Where(x => x.id == int.Parse(parts[1])).First();
                         p.TeamCompetingID = int.Parse(parts[1]);

                     }

                p.score = double.Parse(parts[2]);
                if (parts[3] == "0")
                {
                    p.ParentMatchupID = 0;
                }
                else p.ParentMatchupID = int.Parse(parts[3]); 
                output.Add(p);
            }
            return output;
        }
        
        public static List<MatchupModel> convertToMatchuplList(
            this List<string> lines, 
            string MatchentrieFile,
            string MatchupFile,
            string teamFile,
            string peopleFile)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            List<teamModel> teams = teamFile.getFullpath().loadFile().convertToteamModelList(peopleFile);
            List<MatchupEntrieModel> entires = MatchentrieFile.getFullpath().loadFile().convertToMatchEntryModelList(teamFile, MatchupFile, peopleFile, MatchentrieFile);
           
            
            //if (parts[3] == " ")
            //{
            //    p.ParentMatchupID = 0;
            //}

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                MatchupModel p = new MatchupModel();
                p.id = int.Parse(parts[0]);
                string[] EntredTeams= parts[1].Split('^');
                foreach (string s in EntredTeams)
                {
                    p.Entries.Add(entires.Where(x => x.id == int.Parse(s)).First());
                }
                
                if (parts[2] == "0")
                {
                    p.Winner = null;
                }
                else p.Winner = teams.Where(x => x.id == int.Parse(parts[2])).First();

                
                p.MatchupRound = int.Parse(parts[3]);
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
                
                if (team.teamCompreting!=null)
                {
                    team.TeamCompetingID = team.teamCompreting.id;
                }else team.TeamCompetingID = 0;

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
            //lines.Add($"{tr.id} , {tr.TouramentName} ," +
            //    $"{tr.EntryFee}," +
            //    $" {convertTeamEntriesListToString(tr.EnteredTeams)}," +
            //    $"{convertTourPrizesListToString(tr.Prizes)},{convertTourRoumdListToString(tr.round)}");
            
            List<tourement_Model> trs = new List<tourement_Model>();
            List<teamModel> teams = teamfile.getFullpath().loadFile().convertToteamModelList(peopleFile);
            List<PrizeModel> prizes = prizeFile.getFullpath().loadFile().convertToPrizeModel();
            List<MatchupModel> matchups=matchupFile.getFullpath().loadFile().convertToMatchuplList(matchupEntryFile,matchupFile,teamfile,peopleFile);
            List<MatchupEntrieModel> entries = matchupEntryFile.getFullpath().loadFile().convertToMatchEntryModelList(teamfile, matchupFile, peopleFile, matchupEntryFile);

            foreach (MatchupModel matchup in matchups)
            {
                foreach (MatchupEntrieModel entry in matchup.Entries)
                {
                    if (entry.matchupParent!=null)
                    {
                        entry.matchupParent = matchups.Where(x => x.id == entry.ParentMatchupID).First();

                    }
                }
            }

            /// id,touramentName,fee,(team1^team2^team3),(prize*prize1*prize2), (round id^id^id|id^id^id..)..
            foreach (string line in lines)
            {
                string[] trParts = line.Split(',');
                tourement_Model p = new tourement_Model();
                List<MatchupModel> e = new List<MatchupModel>();
                p.id = int.Parse(trParts[0]);
                p.TouramentName = trParts[1];
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
                //(round Matchup id ^ id ^ id | id ^ id ^ id..)
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
                    
                    p.round.Add(mathups);
                    mathups = new List<MatchupModel>();


                }
                p.Active =int.Parse( trParts[6]);
                trs.Add(p);
            }
            return trs;

        }
        












    }
}
