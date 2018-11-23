using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class ExecutionUser
    {
        //INT
        public int userID { get; set; }
        public int roleID { get; set; }
        //STRING
        public string userName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string GID { get; set; }
        public string email { get; set; }


        public ExecutionUser(int userID, int roleID, string userName, string firstName, string middleName, string lastName, string GID, string email)
        {
            this.userID = userID;
            this.roleID = roleID;
            this.userName = userName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.GID = GID;
            this.email = email;
        }
    }
}
