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

                connection.Execute("PeopleInsert", p, commandType: CommandType.StoredProcedure);

                person1.id = p.Get<int>("@id");

            }
            return person1;
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
    }
}
