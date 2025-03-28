using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitsHeaderEditor
{
    public class HeaderField
    {
        private static string[] NOVALUE_FIELD = { "COMMENT", "HISTORY", "" };
        private static string[] MANDATORY_FIELD = { "SIMPLE", "END", "BITPIX" };

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
            return this.key != null && NOVALUE_FIELD.Contains(this.key.Trim());
        }

        public bool isMandatory()
        {
            return this.key != null && MANDATORY_FIELD.Contains(this.key.Trim());
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
            int value_end_idx = 70;
            if (string.IsNullOrEmpty(valueIndicator()))
                value_end_idx = 72;

            return 
                key.PadRight(8).Substring(0, 8)
                + valueIndicator() 
                + value.PadRight(value_end_idx).Substring(0, value_end_idx);
        }

        private string valueIndicator()
        {
            if (this.key == null || this.key.Trim() == "END") return "";
            if (this.isCommentaryKeyword()) return "";
            return "= ";
        }
    }
}
