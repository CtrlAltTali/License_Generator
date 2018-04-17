using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace License_Generator
{
    class Encode_web : Encode
    {
        public Encode_web(string IP) : base(IP) { }

        public override string Get_License(string info, string feature, string costumer)
        {
            string output = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    System.Collections.Specialized.NameValueCollection collection =
                        new System.Collections.Specialized.NameValueCollection();
                    collection.Add("text", info);
                    collection.Add("ax", feature);
                    collection.Add("cust", StaticVars.costumers[costumer]);
                    client.Proxy = null;
                    //MessageBox.Show(collection.GetValues("text")[0].ToString());
                    byte[] result = client.UploadValues(IP, "POST", collection);
                    int[] indexarray = new int[2];
                    int newlinecount = 0;
                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] == 10 && newlinecount < 2)
                        {
                            indexarray[newlinecount] = i;
                            newlinecount++;
                        }
                            
                    }
                    if (newlinecount > 1)
                        result = result.Skip(indexarray[0]).Take(indexarray[1] - indexarray[0]).ToArray();
                    else
                        result = result.Skip(indexarray[0]).ToArray();

                    output = System.Text.Encoding.Default.GetString(result);
                    output = output.Replace("</br>", "").Replace("/n","");

                    if (output.Contains("try again"))
                        output = "";
                }
                catch (WebException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return output;
        }
        public override void CheckIfReachable(string IP)
        {
            System.Net.WebClient web = new System.Net.WebClient();

            try
            {
                System.IO.Stream stream = web.OpenRead(IP);
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    String text = reader.ReadToEnd();
                    if (!text.Contains("submit"))
                        StaticVars.serverException = "Web server cannot be reached";
                }
            }
            catch (Exception e)
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
