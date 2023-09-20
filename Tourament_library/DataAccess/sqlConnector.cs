using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tourament_library.Models;

namespace Tourament_library.DataAccess
{
    public class sqlConnector : IDataConnection
    {
        const string db = "tourament";

        public PrizeModel createPrize(PrizeModel model)
        {
            
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@placeName", model.placeName);
                    p.Add("@prizeAmount", model.prizeAmount);
                    p.Add("@prizePercentage", model.prizePercentage);
                    p.Add("@placeNumber", model.placeNumber);

                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("sp_prizeInsert", p, commandType: CommandType.StoredProcedure);

                    model.id = p.Get<int>("@id");
                }

                return model;
            
           
        }
        public person ceatePeson(person person1)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {
                    //@name nvarchar(15),
                    //@lastName nvarchar(15),
                    //@email nvarchar(20),
                    //@phone nchar(20),
                    //@id int = 0 output

                var p = new DynamicParameters();
                p.Add("@name", person1.name);
                p.Add("@lastName", person1.lastName);
                p.Add("@email", person1.email);
                p.Add("@phone", person1.phone);

                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                //// this command so we can imploment the input inside of stored procedure
                connection.Execute("PeopleInsert", p, commandType: CommandType.StoredProcedure);

                person1.id = p.Get<int>("@id");

            }
            return person1;
        }
        public teamModel createTeam(teamModel team)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {


                var p = new DynamicParameters();
                p.Add("@teamName", team.teamName);


                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("sp_teamInsert", p, commandType: CommandType.StoredProcedure);

                team.id = p.Get<int>("@id");
                foreach (var tm in team.team_member)
                {
                    p = new DynamicParameters();
                    p.Add("@teamID", team.id);

                    // tm is the team member people id
                    p.Add("@peopleID", tm.id);

                    connection.Execute("sp_teamMemberInsert", p, commandType: CommandType.StoredProcedure);
                }
                return team;

            }
        }
        public void createTourament(tourement_Model tr)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@touramentName", tr.TouramentName);
                p.Add("@entrieFee", tr.EntryFee);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("sp_TouramentInsert", p, commandType: CommandType.StoredProcedure);

                tr.id = p.Get<int>("@id");
                // entries inserts
                foreach (var tm in tr.EnteredTeams)
                {
                    p = new DynamicParameters();
                    p.Add("@touramentID", tr.id);
                    p.Add("@teamID", tm.id);

                    connection.Execute("sp_touramentEntriesInsert", p, commandType: CommandType.StoredProcedure);
                }
                // insert prizes
                foreach (var tm in tr.Prizes)
                {
                    p = new DynamicParameters();
                    p.Add("@touramentID", tr.id);
                    p.Add("@PrizeID", tm.id);

                    connection.Execute("sp_TouramentPrizesInsert", p, commandType: CommandType.StoredProcedure);
                }
                // round insert
                foreach (List<MatchupModel> round in tr.round)
                {
                    // save a list of list  List<list<MatchModel>>
                    // list<matchupEntrie> entries
                    // loop throw the rounds
                    //than loop inside loop to get matchup
                    //save the matchup\
                    // lopp throght the enties ad save them
                    foreach (MatchupModel match in round)
                    {
                        
                        p = new DynamicParameters();
                        p.Add("@MatchupRound", match.MatchupRound);
                        p.Add("@touramentID", tr.id);
                        // -todo Matchup  winner didnt setup
                        p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                        connection.Execute("sp_MatchupsInsert", p, commandType: CommandType.StoredProcedure);
                        match.id = p.Get<int>("@id");

                        foreach (MatchupEntrieModel entry in match.Entries  )
                        {
                            p = new DynamicParameters();
                            p.Add("@MatchupID", match.id);
                            if ( entry.matchupParent!=null)
                            {
                                p.Add("@ParentMatchupID", entry.matchupParent.id);
                            }
                            else {
                                p.Add("@ParentMatchupID", null);
                               
                            }
                            if (entry.teamCompreting != null )
                            {
                                p.Add("@TeamCompetingID", entry.teamCompreting.id);
                            }
                            else
                            {
                                p.Add("@TeamCompetingID", null);
                            }
                            // -todo TeamEntries score didnt setup
                            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                            connection.Execute("sp_matchUpsEntriesInsert", p, commandType: CommandType.StoredProcedure);
                            
                        }
                    }


                }


                

            }
        }


        public List<person> getPersonAll( )
        {
            List<person> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {
                output = connection.Query<person>("sp_peopleGetAll").ToList();
            }
            return output;
        }

        
        public List<teamModel> getTeamAll()
        {
            List<teamModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {
                output = connection.Query<teamModel>("sp_teamGetAll").ToList();
                foreach (teamModel team in output)
                {
                    var p = new DynamicParameters();
                    p.Add("@teamID", team.id);
                    team.team_member= connection.Query<person>("sp_teamMember_getByTeam",p
                        , commandType: CommandType.StoredProcedure).ToList();
                }
            }
            return output;
        }

        public List<tourement_Model> getTourAll()
        {
            List<tourement_Model> output;
            List<MatchupModel> matchups = new List<MatchupModel>(); 
            
            List<MatchupEntrieModel> entries = new List<MatchupEntrieModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {
                output = connection.Query<tourement_Model>("sp_touramentGetAll").ToList();
                foreach (tourement_Model tour in output)
                {
                    //                 select Tourament1.id,
                    //Tourament1.TouramentName,
                    //Tourament1.EntryFee,
                    //Tourament1.Active
                    //     from Tourament1
                    var p = new DynamicParameters();
                    var e = new DynamicParameters();
                    var l = new DynamicParameters();


                    p.Add("@TouramentID", tour.id);
                    
                    tour.EnteredTeams = connection.Query<teamModel>("spTeam_getBytouramentID", p
                        , commandType: CommandType.StoredProcedure).ToList();
                    foreach (teamModel team in tour.EnteredTeams)
                    {
                        e.Add("@teamID", team.id);
                        team.team_member = connection.Query<person>("sp_teamMember_getByTeam", e
                        , commandType: CommandType.StoredProcedure).ToList();

                    }
                    tour.Prizes = connection.Query<PrizeModel>("spPrizes_getByTouramentID", p
                        , commandType: CommandType.StoredProcedure).ToList();
                    
                    
                    
                    matchups = connection.Query<MatchupModel>("spMatchup_getTouramentID", p
                    , commandType: CommandType.StoredProcedure).ToList();
                    foreach (MatchupModel mathup in matchups)
                    {
                        l.Add("@matchupID", mathup.id);
                        mathup.Entries = connection.Query<MatchupEntrieModel>("spMatchupEntries_getBymatchupID", l
                        , commandType: CommandType.StoredProcedure).ToList();
                        
                        List<teamModel> teams = getTeamAll();
                        if (mathup.winnerID>0)
                        {
                            mathup.Winner = teams.Where(x => x.id == mathup.winnerID).First();
                        }
                        
                        foreach (MatchupEntrieModel me in mathup.Entries)
                        {
                            if (me.TeamCompetingID >0)
                            {
                                me.teamCompreting=teams.Where(x => x.id == me.TeamCompetingID).First();
                            }
                            if (me.ParentMatchupID > 0)
                            {

                                me.matchupParent = matchups.Where(x => x.id == me.ParentMatchupID).First();
                            }
                        }
                    }
                    
                    // List<List<<teamMOdel>
                    
                    List<MatchupModel> round= new List<MatchupModel>();
                    int currRound = 1;
                    foreach (MatchupModel mathup in matchups)
                    {
                        if (mathup.MatchupRound == currRound)
                        {
                            round.Add(mathup);
                        }
                        else
                        {
                            tour.round.Add(round);
                            round = new List<MatchupModel>();
                            round.Add(mathup);
                            currRound++;
                        }
                        
                    }
                    tour.round.Add(round);




                }
            }
            return output;
        }
        



    }
}
