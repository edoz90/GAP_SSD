using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heuristics
{
    public class MyTraceListener : TraceListener
    {
        private TextBoxBase output;

        public MyTraceListener(TextBoxBase output)
        {
            this.Name = "Trace";
            this.output = output;
        }

        public override void Write(string message)
        {
            Action append = delegate()
            {
                output.AppendText(message);
            };

            if (output.InvokeRequired)
                output.BeginInvoke(append);
            else
                append();
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);
            //output.Select(output.Text.Length,0);
            //output.ScrollToCaret(); 
        }
    }
}
