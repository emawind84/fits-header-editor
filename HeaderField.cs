using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitHeaderReader
{
    class HeaderField
    {
        public string key { get; set; }

        public string value { get; set; }

        public HeaderField(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
