﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitsHeaderEditor
{
    public static class ExceptionExtension
    {

        internal static Exception Log(this Exception ex)
        {
            LogUtil.Log(ex.Message + "\n" + ex.ToString(), "CaughtExceptions_" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");

            return ex;
        }

        internal static Exception Display(this Exception ex, string msg = null, MessageBoxIcon icon = MessageBoxIcon.Error)
        {
            MessageBox.Show(msg ?? ex.Message, "", MessageBoxButtons.OK, icon);
            return ex;
        }
    }
}
