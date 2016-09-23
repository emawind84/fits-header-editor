using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FitHeaderReader
{
    class Trash
    {

        string filepath;
        BindingSource datagrid;

        /// <summary>
        /// OLD
        /// </summary>
        /// <returns></returns>
        private byte[] updateFitsHeader()
        {
            char[] buffer = null;
            StringBuilder resultBuilder = new StringBuilder();
            //Dictionary<string, string> header = new Dictionary<string, string>();
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fs, Encoding.ASCII))
            {
                buffer = new char[80];
                while (streamReader.ReadBlock(buffer, 0, (int)buffer.Length) != 0)
                {
                    string result = new string(buffer);
                    string key = result.Substring(0, 8);

                    if (result.Substring(8, 2) == "= " )
                    {
                        foreach (HeaderField field in datagrid.List)
                        {
                            if (field.key == key)
                            {
                                result = field.key + "= " + field.value;
                                //Console.WriteLine("Updating header {0} = {1}", field.key, field.value);
                            }
                        }
                    }
                    
                    resultBuilder.Append(result);
                    
                    if (result.Trim() == "END")
                    {
                        break;
                    }
                }

            }
            
            return System.Text.Encoding.ASCII.GetBytes(resultBuilder.ToString());
        }

        private string createValue(string value)
        {
            char[] buffer = new char[70];
            for (int i = 0; i < buffer.Length; i++)
            {
                try
                {
                    buffer[i] = value.Substring(i, 1)[0];
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Value too long {0}", value);
                }
            }

            return new string(buffer);
        }
    }
}
