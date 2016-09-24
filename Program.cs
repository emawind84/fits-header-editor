using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.ObjectModel;

namespace FitsHeaderEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] args = Environment.GetCommandLineArgs();
            SingleInstanceController controller = new SingleInstanceController();
            controller.Run(args);
            
        }
    }

    public class SingleInstanceController : WindowsFormsApplicationBase
    {

        public SingleInstanceController()
        {
            IsSingleInstance = true;

            StartupNextInstance += this_StartupNextInstance;
        }

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            Form1 form = MainForm as Form1; //My derived form type

            var args = e.CommandLine;
            if (args.Count > 1)
            {
                form.LoadFile(e.CommandLine[1]);
            }
        }

        protected override void OnCreateMainForm()
        {
            var args = this.CommandLineArgs;
            MainForm = new Form1(args.Count == 1 ? string.Empty : args[1]);
        }
    }
}
