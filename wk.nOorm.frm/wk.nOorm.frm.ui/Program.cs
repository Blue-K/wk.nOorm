using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wk.nOorm.frm.ui
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

            cOnexion _conexion = new cOnexion();
            DialogResult _result = _conexion.ShowDialog();

            if (_result == DialogResult.OK)
            {
                Application.Run(new pRincipal(_conexion.aCcesoDatos));
            }
        }
    }
}
