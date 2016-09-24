using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FitsHeaderEditor
{
    class FitsFile
    {
        private string name;
        public string Name {
            get
            {
                return this.name;
            }
            set {
                name = value;
            }
        }
        public string FilePath { get; set; }

        public FitsFile(string filepath)
        {
            var finfo = new FileInfo(filepath);
            this.Name = finfo.Name;
            this.FilePath = finfo.FullName;
        }

        public FitsFile(string filepath, string name)
        {
            this.Name = name;
            this.FilePath = filepath;
        }

        public override bool Equals(object obj)
        {
            if (FilePath.Equals((obj as FitsFile).FilePath))
            {
                return true;
            }
            return base.Equals(obj);
        }
    }
}
