using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitsHeaderEditor
{
    class HeaderField
    {
        // readonly flag
        private bool ReadOnly { get; set; } = false;

        private static bool trimmed = false;
        public static bool Trimmed
        {
            get
            {
                return trimmed;
            }
            set
            {
                trimmed = value;
            }
        }

        private string key;
        public string Key
        {
            get
            {
                return key != null ? key : "";
            }
            set
            {
                if (!isReadOnly())
                    key = value;
            }
        }

        private string value;
        public string Value {
            get {
                if (Trimmed && value != null) return value.Trim();
                return value != null ? value : "";
            }
            set {
                if (!isReadOnly())
                    this.value = value;
            }
        }

        public HeaderField() { }

        public HeaderField(string key, string value = null)
        {
            this.key = key == null ? "" : key;
            this.value = value == null ? "" : value;
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

        public bool isReadOnly()
        {
            return ReadOnly || trimmed;
        }

        public static HeaderField EndKeyword()
        {
            HeaderField f = new HeaderField("END", "");
            return f;
        }

        public override string ToString()
        {
            string skey = key;
            string svalue = value.PadRight(70).Substring(0, 70);

            /*float fvalue; int ivalue;
            if ( float.TryParse(svalue.Substring(0, 20), out fvalue) )
            {
                svalue = fvalue.ToString().PadLeft(20);
            }
            else if (int.TryParse(svalue.Substring(0, 20), out ivalue))
            {
                svalue = ivalue.ToString().PadLeft(20);
            }*/

            return 
                skey.PadRight(8).Substring(0, 8)
                + valueIndicator() 
                + svalue.PadRight(70).Substring(0, 70);
        }

        private string valueIndicator()
        {
            if (this.key.Trim() == "END") return "  ";
            if (this.isCommentaryKeyword()) return "  ";
            return "= ";
        }
    }
}
