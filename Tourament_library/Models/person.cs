using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourament_library.Models
{
    public class person
    {
        public string name;
        public string lastName;
        public string email;
        public string phone;
        public int id;

        public person(string name, string lastName, string email_adress, string phonenumber)
        {
            this.name = name;
            this.lastName = lastName;
            this.email = email_adress;
            this.phone = phonenumber;
        }
        public string fullname
        {
            get
            {
                return $"  {name} {lastName}";
            }
        }
        public person()
        {
           
        }
    }
}
