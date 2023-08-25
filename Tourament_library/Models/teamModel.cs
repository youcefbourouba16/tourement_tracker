using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourament_library.Models
{
    public class teamModel
    {
        /// <summary>
        /// has the the information of players
        /// </summary>
        public List<person> team_member { get; set; } = new List<person>() { };
        public string teamName { get; set; }
        public int id { get;set; }
    }
}
