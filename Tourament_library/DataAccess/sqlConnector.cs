using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.Models;

namespace Tourament_library.DataAccess
{
    public class sqlConnector : IDataConnection
    {
        public PrizeModel createPrize(PrizeModel model)
        {
            
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(globalConfig.CnnString("tourament")))
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
    }
}
