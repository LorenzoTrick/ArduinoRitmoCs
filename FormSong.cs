using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduBeats
{
    /**
     * @class FormSong
     * @brief Classe che gestisce il form canzone
     */
    public partial class FormSong : Form
    {
        private static FormSong _instance = null;

        private BeatBitMasker bbm;

        private ScoreSharer ss;

        private Chart chart;

        public static FormSong StartInstance(DirectoryInfo chartPath)
        {
            if (_instance == null)
                _instance = new FormSong(chartPath);

            return _instance;
        }

        private static void StopInstance()
        {
            _instance = null;
        }

        private FormSong(DirectoryInfo chartPath)
        {
            this.chart = new Chart(chartPath);
            bbm = new BeatBitMasker();
            ss = ScoreSharer.StartInstance();
            InitializeComponent();
            labelName.Text = chartPath.Name;
            chart.Start();
        }

        private void FormSong_FormClosed(object sender, FormClosedEventArgs e)
        {
            chart.Stop();
            ss.Reset();
            StopInstance();
        }

        private void ScoreUpdateTimer_Tick(object sender, EventArgs e)
        {
            labelPerfect.Text = ss.perfectCount.ToString();
            labelGreat.Text = ss.greatCount.ToString();
            labelBad.Text = ss.badCount.ToString();
            labelMiss.Text = ss.missCount.ToString();
            labelAccuracy.Text = ss.GetAccuracy().ToString("0.00") + " %"; 
        }
    }
}
