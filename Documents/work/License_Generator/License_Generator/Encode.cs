using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License_Generator
{
    class Encode
    {
        public virtual string Get_License(string code, string feature, string serial_num)
        {
            return "a";
        }
        public virtual bool Verify(string license, string code, string serial_num)
        {
            if (license == "a")
                return true;
            return false;
        }
    }
}
