using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourament_library.DataAccess;

namespace Tourament_library
{
    public static class globalConfig
    {
        /// <summary>
        /// list of data connection
        /// </summary>
        public static IDataConnection Connections { get; private set; }

        /// <summary>
        /// saving data either in database or text files or both
        /// </summary>
        /// <param name="dataBase"></param>
        /// <param name="textFile"></param>
        public static void InitializingConnection(DatabaseType connectonType)
        {
            // instead of  new List<IDataConnection>(); we can use
            // Connections = new List<IDataConnection>();



            // enums are wonder full with switch cases
            //switch (connectonType)
            //{
            //    case DatabaseType.sql:
            //        break;
            //    case DatabaseType.TextFile:
            //        break;
            //    default:
            //        break;
            //}
            if (connectonType==DatabaseType.sql)
            {
                // TODO - set up sql connection propely
                sqlConnector sql = new sqlConnector();
                Connections = sql;

            }else if (connectonType == DatabaseType.TextFile)
            {
                // TODO - set up text file  connection propely
                textConnection text = new textConnection();
                Connections = text;
            }
        }

        public static String CnnString(String name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
