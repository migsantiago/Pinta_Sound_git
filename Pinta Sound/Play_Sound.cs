using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace Pinta_Sound
{
    class Play_Sound
    {
        //---------------------------------------------------------------------------------
        //Objects

        private SoundPlayer player;

        //---------------------------------------------------------------------------------
        //Methods

        public Play_Sound()
        {
            // Set up the SoundPlayer object.
            InitializeSound();
        }

        // Sets up the SoundPlayer object. 
        private void InitializeSound()
        {
            // Create an instance of the SoundPlayer class.
            player = new SoundPlayer();
        }

        public void Play_Wav(String filename)
        {
            player.SoundLocation = filename;
            player.Play();
        }

        public void Stop_Wav()
        {
            player.Stop();
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
