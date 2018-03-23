using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitsHeaderEditor
{
    public class PrintUtil
    {
        private StringReader streamToPrint;

        public void PrintHeaders(string headers)
        {
            PrintDocument pd = new PrintDocument();
            Margins margins = new Margins(40, 40, 40, 40);
            pd.DefaultPageSettings.Margins = margins;
            pd.PrintPage += new PrintPageEventHandler(Pd_PrintPage);

            PrintDialog pdi = new PrintDialog();

            if (pdi.ShowDialog() == DialogResult.OK)
            {
                streamToPrint = new StringReader(headers);
                pd.Print();
            }
            else
            {
                //MessageBox.Show("Print Cancelled");
            }

        }

        // The PrintPage event is raised for each page to be printed.
        private void Pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            var printFont = new Font("Arial", 10);
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            while (count < linesPerPage && 
                ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
    }
}
