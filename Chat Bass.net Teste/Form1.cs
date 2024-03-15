using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Fx;
using Un4seen.Bass.Misc;



namespace Chat_Bass.net_Teste
{
    public partial class Form1 : Form
    {
        double volume = 0.01;
        public Form1()
        {
            InitializeComponent();
            //BassNet.Registration(tozecerdeira@proton.me, 2X1824322253723);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize BASS.NET
            
            //if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
            //{
            //    MessageBox.Show("BASS_Init error: " + Bass.BASS_ErrorGetCode());
            //    return;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.ogg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                // Load audio file

                var _stream = Bass.BASS_StreamCreateFile(fileName, 0, 0, BASSFlag.BASS_DEFAULT);

                if (_stream == 0)
                {
                    MessageBox.Show("BASS_StreamCreateFile error: " + Bass.BASS_ErrorGetCode());
                    return;
                }

                // Apply effect (reverb)
                
                

                //BASS_BFX_REVERB;
                //BASS_BFX_REVERB(1, 5000);

                //DSP_Reverb reverb = new DSP_Reverb(_stream);
                
                //reverb.FX_Bypass = false; // Enable the effect
                //reverb.RoomSize = 0.5f;   // Set room size (adjust as needed)
                //reverb.Damp = 0.5f;       // Set damping (adjust as needed)
                //reverb.Wet = 0.5f;        // Set wet level (adjust as needed)
                //reverb.Dry = 0.5f;        // Set dry level (adjust as needed)
                
                //// Add the effect to the stream
                //reverb.AddToStream(_stream, BASSFXChan.BASS_BFX_CHANALL);
                
                // Play the modified audio
                Bass.BASS_ChannelPlay(_stream, false);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //label2.Text = volume.ToString();
            Bass.BASS_Init(-1,44100,BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            // Codigo para funcionar o play
            int stream = Bass.BASS_StreamCreateFile(@"c:\mp3\forest.mp3", 0, 0, BASSFlag.BASS_DEFAULT);
            // Depois de tantas tenatativas descobri !! é preciso definir o volume do player !
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, ((float)volume));
            Bass.BASS_ChannelPlay(stream, false);
            
            //Bass.BASS_StreamFree(stream);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            
            string mp3file = @"c:\mp3\amarteassim.mp3";

            int stream = Bass.BASS_StreamCreateFile(mp3file, 0, 0, BASSFlag.BASS_DEFAULT);
            //int stream = Bass.BASS_StreamCreateFile(mp3file, 0, 0, BASSFlag.BASS_SAMPLE_FLOAT);

            //BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_PRESCAN);

            if (stream != 0 && Bass.BASS_ChannelPlay(stream, false))
            {
                
                //Bass.BASS_ChannelGetAttribute(stream, BASSAttribute.BASS_ATTRIB_REVERSE_DIR, volume);
                Bass.BASS_ChannelPlay(stream, false);
            }
            else
            {
                Console.WriteLine("Error={0}", Bass.BASS_ErrorGetCode());
            }
            Bass.BASS_StreamFree(stream);
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            volume = trackBarVolume.Value*0.01;
            label2.Text = trackBarVolume.Value.ToString();
        }
    }
}
