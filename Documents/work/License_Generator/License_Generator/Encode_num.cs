using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License_Generator
{
    class Encode_num: Encode
    {

        public Encode_num(string IP, string user,string keyName) : base(IP, user, keyName) { }

        //this method generates license
        public override string Get_License(string code, string feature, string serial_num)
        {
            //command that tells cmd to go go to PLINK.exe's dir 
            //pathcommand = "cd " + plink;

            //command for generating the actual license from the server
            licensecommand = "plink -batch -i " + keyName + " " + user + "@" + IP + " ./mcuac -h " + code + " -n " + feature + " -s " + serial_num;

            //the two commands are needed to be joind with an && so the cmd will run the 2nd command only after the 1st one has succeeded to run
            string strCmdTxt = "/c " + licensecommand;

            //BeginProcess is called to execute the two commands
            BeginProcess(strCmdTxt);

            //extracting the license number
            string license = "";
            if (output != null)
            {
                int found = output.IndexOf("[ ");
                if (found != -1 && output.Contains("verified"))
                {
                    license = output.Substring(found + 2);
                    found = license.IndexOf(" ]");
                    license = license.Substring(0, found);
                }
            }

            return license;
        }

        //this method verifies that a license number was created
        public override bool Verify()
        {
            return base.Verify();
        }

        //this method executes the commands on the cmd
        public override void BeginProcess(string cmdcommand)
        {
            base.BeginProcess(cmdcommand);
        }
        
    }
}
