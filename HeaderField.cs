using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitsHeaderEditor
{
    class HeaderField
    {
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
                this.value = value;
            }
        }

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
            HeaderField f = new HeaderField("END", "");
            return f;
        }

        public override string ToString()
        {
            return this.Key.PadRight(8) + valueIndicator() + this.Value.PadRight(70);
        }

        private string valueIndicator()
        {
            if (this.key.Trim() == "END") return "  ";
            if (this.isCommentaryKeyword()) return "  ";
            return "= ";
        }
    }
}
