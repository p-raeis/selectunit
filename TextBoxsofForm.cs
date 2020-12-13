using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selection
{
    static class TextBoxsofForm
    {
        public static bool IsNullOrEmpty(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                    if (string.IsNullOrEmpty((control as TextBox).Text))
                        return true;
            }
            return false;
        }
    }
}
