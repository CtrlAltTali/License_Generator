using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace License_Generator
{
    class Encode
    {
        protected string IP;
        protected string user;
        protected string plink;
        protected string licensecommand;
        protected string pathcommand;
        protected string keyName;
        protected string output = "";
        protected string err = "";
        public Encode(string IP, string user, string plink_path, string keyName)
        {
            this.IP = IP;
            this.user = user;
            this.plink = plink_path;
            this.keyName = keyName;
        }

        //this method generates license
        public virtual string Get_License(string code, string feature, string serial_num)
        {
            //command that tells cmd to go go to PLINK.exe's dir         
            pathcommand = "cd " + plink;

            //command for generating the actual license from the server
            licensecommand = "plink -i " + keyName + " " + user + "@" + IP + " ./mcuac -h " + code + " -f " + feature + " -s " + serial_num;

            //the two commands are needed to be joind with an && so the cmd will run the 2nd command only after the 1st one has succeeded to run
            string strCmdTxt = "/c " + pathcommand + " && " + licensecommand;

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
        public virtual bool Verify()
        {
            if (output.Contains("verified"))
                return true;
            return false;
        }

        //this method executes the commands on the cmd
        public virtual void BeginProcess(string cmdcommand)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo i = new System.Diagnostics.ProcessStartInfo("cmd.exe", cmdcommand);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = i;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.Start();
                while (!p.StandardOutput.EndOfStream)
                {
                    output = p.StandardOutput.ReadLine();
                }

                err = p.StandardError.ReadToEnd();
                p.WaitForExit();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
