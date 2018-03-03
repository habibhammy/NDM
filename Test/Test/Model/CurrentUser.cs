using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    static class CurrentUser
    {
        public static Users currentuser;

        public static bool Isadmin()
        {
            if (currentuser!=null &&  currentuser.Login.Equals("Admin"))
                return true;

            return false;
        }

        public static void Initcurrentuser(Users u) => currentuser = u;
    }
}
