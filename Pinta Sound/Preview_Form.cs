using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Shell;

namespace Pinta_Sound
{
    public partial class Preview_Form : GlassForm
    {
        public Preview_Form()
        {
            InitializeComponent();
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
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

