using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitsHeaderEditor
{
    public static class FitsUtil
    {
        public static void WriteFitsHeader(IList headerCollection, string file, string newfile = null)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            //byte[] header = encoding.GetBytes(consoleResultTextBox.Text.Replace(System.Environment.NewLine, ""));

            byte[] header = updateFitsHeader(headerCollection);
            byte[] data = new byte[0];

            if (file != null)
            {
                // extract image data from file
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    int header_end = findHeaderLength(file);

                    data = new byte[fs.Length - header_end];
                    fs.Seek(header_end, SeekOrigin.Begin);
                    fs.Read(data, 0, data.Length);
                }
            }

            // write new header with image data
            newfile = newfile != null ? newfile : file;
            using (FileStream fs = new FileStream(newfile, FileMode.Create, FileAccess.Write))
            {
                //fs.Seek(0, SeekOrigin.Begin);

                using (BinaryWriter streamWriter = new BinaryWriter(fs, Encoding.ASCII))
                {
                    streamWriter.Write(header);
                    streamWriter.Write(data);
                }
            }

        }

        public static string[] ProcessHeaderString(string headerString)
        {
            Console.WriteLine("Reading line: {0}", headerString);
            if (headerString.Trim() == "END")
            {
                return null;
            }

            string key = headerString.Substring(0, 8);
            string divisor = headerString.Substring(8, 2);
            int value_start_idx = 10;

            if (divisor != "= ")  // check if the field has no value
            {
                value_start_idx = 8;
                Console.WriteLine("Found comment: {0}", headerString);
            }
            string value = headerString.Substring(value_start_idx, 70);
            return new string[] { key, value };
        }

        public static List<HeaderField> ReadFitsHeaderFromFile(string filepath)
        {
            var f = new FileInfo(filepath);
            if (!f.Exists) throw new FileNotFoundException().Log();

            char[] buffer = null;
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);

            List<HeaderField> header = ReadFitsHeaderFromStream(fs);
            return header;
        }

        public static List<HeaderField> ReadFitsHeaderFromStream(Stream stream)
        {
            char[] buffer = null;
            List<HeaderField> header = new List<HeaderField>();
            
            using (StreamReader streamReader = new StreamReader(stream, Encoding.ASCII))
            {
                buffer = new char[80];
                while (streamReader.ReadBlock(buffer, 0, (int)buffer.Length) != 0)
                {
                    string[] parsedHeader = ProcessHeaderString(new string(buffer));
                    if (parsedHeader == null) break;
                    header.Add(new HeaderField(parsedHeader[0], parsedHeader[1]));
                }

            }

            return header;
        }

        private static byte[] updateFitsHeader(IList header)
        {
            StringBuilder resultBuilder = new StringBuilder();
            foreach (HeaderField field in header)
            {
                if (field.isEmpty()) continue;
                resultBuilder.Append(field.ToString());
            }

            // add the END keyword to end the header
            resultBuilder.Append(HeaderField.EndKeyword());

            // fill the right side of END with spaces if required

            int pad_length = resultBuilder.Length % 2880;
            if (pad_length != 0)
            {
                resultBuilder.Append("".PadRight(2880 - pad_length));
            }

            return System.Text.Encoding.ASCII.GetBytes(resultBuilder.ToString());
        }

        private static int findHeaderLength(string filepath)
        {
            int header_end = 0;
            // extract image data from file
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fs, Encoding.ASCII))
                {
                    char[] buffer = new char[80];
                    while (streamReader.Read(buffer, 0, buffer.Length) != 0)
                    {
                        header_end += 80;
                        //Console.WriteLine(header_end);

                        string f = new string(buffer);
                        if (f.Trim() == "END")
                        {
                            break;
                        }

                    }

                    int pad_length = header_end % 2880;
                    if (pad_length != 0)
                    {
                        header_end += (2880 - pad_length);
                    }
                }

            }
            Console.WriteLine("header length " + header_end);
            return header_end;
        }
    }
}
