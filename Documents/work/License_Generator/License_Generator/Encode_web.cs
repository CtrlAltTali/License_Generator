using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace License_Generator
{
    class Encode_web: Encode
    {
        public Encode_web(string IP) : base(IP) { }

        public override string Get_License(string code, string feature, string serial_num)
        {
            return "s";
        }
        public override void CheckIfReachable(string IP)
        {
            System.Net.WebClient web = new System.Net.WebClient();
            
            try
            {
                System.IO.Stream stream = web.OpenRead("http://" + IP + "/");
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    String text = reader.ReadToEnd();
                    if (!text.Contains("submit"))
                        StaticVars.serverException = "Web server cannot be reached";
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                StaticVars.serverException = e.Message;
            }
            
        }
        public override bool Verify()
        {
            return base.Verify();
        }
    }
}
