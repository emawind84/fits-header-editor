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

        public HeaderField() { }

        public HeaderField(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public bool isEmpty()
        {
            return this.key == null || this.value == null;
        }

        public bool isCommentaryKeyword()
        {
            string tkey = this.key.Trim();
            return tkey == "COMMENT" || tkey == "HISTORY" || tkey == "";
        }

        public bool isMandatory()
        {
            string tkey = this.key.Trim();
            return tkey == "SIMPLE" || tkey == "END" || tkey == "BITPIX";
        }

        public static HeaderField EndKeyword()
        {
            HeaderField f = new HeaderField("END".PadRight(8), "".PadRight(70));
            return f;
        }

        public override string ToString()
        {
            return this.key + valueIndicator() + this.value;
        }

        private string valueIndicator()
        {
            if (this.key.Trim() == "END") return "  ";
            if (this.isCommentaryKeyword()) return "  ";
            return "= ";
        }
    }
}
