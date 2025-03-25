using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCMagTek
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
      // Check for command line args
        bool startWithBackSelected = args.Length > 0 && args[0].ToLower() == "back";
            
            Application.Run(new Form1(startWithBackSelected));
        }
    }
}
