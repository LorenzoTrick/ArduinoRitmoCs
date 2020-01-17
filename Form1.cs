using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduBeats
{
    public partial class ArduBeats : Form
    {
        DirectoryInfo d;
        DirectoryInfo[] songs;

        private void FillList()
        { 
            foreach (DirectoryInfo song in songs)
            {
                listBoxSongs.Items.Add(song.Name);
            }
        }
        public ArduBeats()
        {
            d = new DirectoryInfo("Songs");
            songs = d.GetDirectories();

            InitializeComponent();
            FillList();
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            FormSong fs = FormSong.StartInstance(songs[listBoxSongs.SelectedIndex]);
            fs.Show();
        }
    }
}
