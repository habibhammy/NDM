using System;
using Xamarin.Forms;

namespace Test
{

    public class MasterPageMenuItem
    {
        public MasterPageMenuItem()
        {
            TargetType = typeof(MasterPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public String Icon { get;  set; }
        public Type TargetType { get; set; }
    }
}