using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace License_Generator
{
    static class XMLHelper
    {
        /// <summary>
        /// checks if the file exists in the application startup dir 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>true if exists, false if not</returns>
        static public bool FileExists(string filename)
        {
            string path = Application.StartupPath + "\\" + filename;
            return File.Exists(path);
        }

        /// <summary>
        /// creates an empty xml file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>the path of the new file</returns>
        static public string CreateBasicXML(string filename)
        {
            string path = Application.StartupPath + "\\" + filename;
            string firstline = "<?xml version='1.0' encoding='UTF-8'?>\n";
            byte[] bytes = Encoding.UTF8.GetBytes(firstline);
            File.WriteAllBytes(path, bytes);
            
            return path;
        }

        /// <summary>
        /// adds an item to the xml file
        /// </summary>
        /// <param name="item"></param>
        /// <param name="filename"></param>
        static public void Add(string item, string filename)
        {
            string path = Application.StartupPath + "\\" + filename;
            if (!FileExists(filename))
                CreateBasicXML(filename);
            if (!ItemExistsInFile(item, filename))
            {
                string line = "<User>" + item + "</User>";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(line);
                }
            }
            
        }

        /// <summary>
        /// checks if the item exists in the xml file
        /// </summary>
        /// <param name="item"></param>
        /// <param name="filename"></param>
        /// <returns>true if exists, false if not</returns>
        static public bool ItemExistsInFile(string item, string filename)
        {
            string path = Application.StartupPath + "\\" + filename;
            string line = "<User>" + item + "</User>";
            bool exists = false;
            using (StreamReader sr = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string l in lines)
                {
                    if (line == l)
                        exists = true;
                }
            }
            return exists;
        }

        /// <summary>
        /// fetches all the users from the xml file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>an array of users</returns>
        static public string[] GetAllItems(string filename)
        {
            string path = Application.StartupPath + "\\" + filename;
            string[] items;
            using (StreamReader sr = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                items = new string[lines.Length - 1];
                for (int i = 1; i < lines.Length; i++)
                {
                    items[i - 1] = lines[i];
                }
            }
            return items;
        }
    }
}
