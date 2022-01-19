using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class OpenForm : Form
    {
        public OpenForm()
        {
            InitializeComponent();
            //Trace data
            try
            {
                FileStream traceLog = new FileStream("DatabaseTrace_Trace.txt", FileMode.OpenOrCreate);
                TextWriterTraceListener traceListener = new TextWriterTraceListener(traceLog);
                Trace.Listeners.Add(traceListener);
                Trace.AutoFlush = true;
            }
            catch
            {
                //nothin'
            }
            Form1 f = new Form1(false, -1);
            f.Show();
            Hid();
        }

        private void Hid()
        {
            this.Hide();
        }
        public static void TraceWrite(string message)
        {
            Trace.WriteLine($"{DateTime.Now} : {message}");
        }
    }
}
