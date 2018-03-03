using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.View
{

    public class MasterDetailPageMenuItem
    {
        public MasterDetailPageMenuItem()
        {
            TargetType = typeof(MasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean Onlyadmin { get; set; }
        public Type TargetType { get; set; }
    }
}