using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            */
            Status myStatus = new Status("Work In Progress");
            Console.WriteLine(myStatus.getName());
            myStatus.setId(12351);
            Console.WriteLine(myStatus);
            Task myTask = new Task();
            myTask.setStatus("Closed");
            Console.WriteLine(myTask.getStatus()+ "test");
            myTask.save(myTask);


        }
    }
}
