using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License_Generator
{
    class Encode_text: Encode
    {
        public override string Get_License(string code, string feature, string serial_num)
        {
            return base.Get_License(code, feature, serial_num);
        }
        public override bool Verify(string license, string code, string serial_num)
        {
            return base.Verify(license, code, serial_num);
        }
    }
}
