![](https://i.imgur.com/AEKS3ID.jpg)

        private void button3_Click(object sender, EventArgs e)  // PLAY BUTTON OK
        {

            // Inicializar
            Bass.BASS_Init(-1,44100,BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            
            // Codigo para funcionar o play
            int stream = Bass.BASS_StreamCreateFile(@"c:\mp3\forest.mp3", 0, 0, BASSFlag.BASS_DEFAULT);
            
            // Depois de tantas tenatativas descobri !! é preciso definir o volume do player !
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, ((float)volume));
            
            Bass.BASS_ChannelPlay(stream, false);            
        }
