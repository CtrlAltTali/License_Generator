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
        string IP;
        string user;
        string plink;
        string licensecommand;
        string pathcommand;
        public Encode(string IP, string user, string plink_path)
        {
            this.IP = IP;
            this.user = user;
            this.plink = plink_path;
        }
        public virtual string Get_License(string code, string feature, string serial_num)
        {
            string output = "";
            string err;
            pathcommand = "cd " + plink;
            licensecommand = "plink -i private.key.ppk " + user + "@" + IP + " ./mcuac -h " + code + " -f " + feature + " -s " + serial_num;

            string strCmdTxt = "/c " + pathcommand + " && " + licensecommand;
            try
            {
                System.Diagnostics.ProcessStartInfo i = new System.Diagnostics.ProcessStartInfo("cmd.exe", strCmdTxt);
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

            // do something with line

            string license = "";
            if(output != null)
            {
                int found = output.IndexOf("[ ");
                if (found != -1)
                {
                    license = output.Substring(found + 2);
                    found = license.IndexOf(" ]");
                    license = license.Substring(0, found);
                }
            }

            return license;
        }
        public virtual bool Verify(string license, string code, string serial_num)
        {
            if (license == "a")
                return true;
            return false;
        }
    }
}
