using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PassMaster.Properties;

namespace PassMaster
{
    class Initialize
    {
        static public void checkTheme(Form Ex)
        {
            if (Settings.Default["Theme"].Equals(0))
            {
                Ex.BackColor = System.Drawing.Color.Black;

                foreach (Control c in Ex.Controls)
                {
                    if (c is Button)
                    {
                        c.BackColor = System.Drawing.Color.Black;
                        c.ForeColor = System.Drawing.Color.White;
                    }
                    if (c is ToolStrip)
                    {
                        c.BackColor = System.Drawing.Color.Black;
                        c.ForeColor = System.Drawing.Color.White;
                        
                    }
                    if (c is Label)
                    {
                        c.BackColor = System.Drawing.Color.Black;
                        c.ForeColor = System.Drawing.Color.White;
                    }

                }
            }
        }
    }
}
