using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pinta_Sound
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Form());
        }
    }
}

/* ------------------------------------------------------------------------------
 * Revision Log
 * 
 * - 05-Apr-2014 Santiago Villafuerte Rev. 1
 *   + First release
 *   
 * --------------------------------------------------------------------------- */

