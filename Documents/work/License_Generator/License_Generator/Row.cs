using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace License_Generator
{
    class Row
    {
        public string ID { get; set; }
        public string info { get; set; }
        public string code { get; set; }
        public string serial_number { get; set; }
        public string feature { get; set; }
        public string license { get; set; }
        public bool verified { get; set; }
        public Row(string ID, string code, string serial_number, string feature, string info)
        {
            this.code = code;
            this.serial_number = serial_number;
            this.feature = feature;
            this.ID = ID;
            this.info = info;
            this.verified = false;
        }
        public Row(string code, string serial_number)
        {
            this.code = code;
            this.serial_number = serial_number;
            this.feature = null;
            this.verified = false;
        }
        public override string ToString()
        {
            return code + " " + serial_number + " " + feature + " " + license + " " + verified;
        }
    }
}
