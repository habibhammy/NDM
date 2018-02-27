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

        public static void Initcurrentuser(Users u) => currentuser = u;
    }
}
