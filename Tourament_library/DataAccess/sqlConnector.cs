using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
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
        public tourement_Model creatTour(tourement_Model model)
        {

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

        public List<PrizeModel> getPrizeAll()
        {
            List<PrizeModel> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {
                output = connection.Query<PrizeModel>("sp_prizesGetAll").ToList();
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

        

        public List<person> getTeamMebmberByTeam()
        {
            List<person> output;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString(db)))
            {
                output = connection.Query<person>("sp_teamMember_getByTeam").ToList();
            }
            return output;
        }


    }
}
