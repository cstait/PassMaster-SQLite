using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PassMaster.Properties;

namespace PassMaster
{
    //this classes purpose is to change each form to the user's default settings
    class Initialize
    {


        //this function checks what the user's property theme is and changes each button to match that
        static public void checkTheme(Form Ex)
        {
            //thise if-if else checks the default theme value and changes the theme based on it
            if (Settings.Default.Theme == 0)
            {
                Ex.BackColor = System.Drawing.Color.White;

                foreach (Control c in Ex.Controls)
                {
                    if (c is Button)
                    {
                        c.BackColor = System.Drawing.Color.White;
                        c.ForeColor = System.Drawing.Color.Black;
                    }
                    if (c is ToolStrip)
                    {
                        c.BackColor = System.Drawing.Color.White;
                        c.ForeColor = System.Drawing.Color.Black;

                    }
                    if (c is Label)
                    {
                        c.BackColor = System.Drawing.Color.White;
                        c.ForeColor = System.Drawing.Color.Black;
                    }

                }
            }
            else if (Settings.Default.Theme == 1)
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
