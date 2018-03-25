using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License_Generator
{
    class Encode_num: Encode
    {
        public Encode_num(string IP, string user, string plink_path) : base(IP,user,plink_path)
        {
        }
        public override string Get_License(string code, string feature, string serial_num)
        {
            int feat = int.Parse(feature);
            return "b";
        }
        public override bool Verify(string license, string code, string serial_num)
        {
            if (license == "b")
                return true;
            return false;
        }
    }
}
