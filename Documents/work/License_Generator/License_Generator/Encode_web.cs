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

        //this method generates license
        public override string Get_License(string info, string feature, string costumer)
        {
            string output = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    //created a collection for the html form
                    System.Collections.Specialized.NameValueCollection collection =
                        new System.Collections.Specialized.NameValueCollection();

                    //added values for the html form object
                    collection.Add("text", info);
                    collection.Add("ax", feature);

                    collection.Add("cust", StaticVars.costumers[costumer]);
                    client.Proxy = null;
                    
                    //post the form and get result
                    byte[] result = client.UploadValues(IP, "POST", collection);

                    //get the first *written* line in the html form
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

                    //if it is our license
                    if (newlinecount > 1)
                        result = result.Skip(indexarray[0]).Take(indexarray[1] - indexarray[0]).ToArray();
                    else
                        result = result.Skip(indexarray[0]).ToArray();

                    output = System.Text.Encoding.Default.GetString(result);
                    output = output.Replace("</br>", "").Replace("/n","");
                    
                    if (output.Contains("try again"))
                    {
                        StaticVars.webserverException = output;
                        output = "";
                    }
                        
                }
                catch (WebException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return output;
        }

        //this method checks if web form can be reached
        public override void CheckIfReachable(string IP)
        {
            System.Net.WebClient web = new System.Net.WebClient();

            try
            {
                System.IO.Stream stream = web.OpenRead(IP);
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    String text = reader.ReadToEnd();
                    if (!text.Contains("submit")) //the submit button only shows up in our form
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
