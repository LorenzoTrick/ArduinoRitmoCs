using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ArduBeats
{
    /**
     * @class NotesPlayer
     * @brief Classe che gestisce il file contenente le note ecc., e le manda quando necessario ad Arduino
     */
    class NotesPlayer
    {
        private Tick beatTimer;
        private SharedSerialPort com;
        private BeatBitMasker bbm;
        private StreamReader sr;

        public float bpm { get; }
        public float offset { get; }

        public NotesPlayer(string filePath)
        {
            beatTimer = new Tick(BeatTimer_Elapsed);
            com = SharedSerialPort.StartInstance();
            bbm = new BeatBitMasker();
            sr = new StreamReader(filePath);

            float.TryParse(ReadLine(), out float bpmt);
            float.TryParse(ReadLine(), out float offsett);

            bpm = bpmt;
            offset = offsett;

            //timer: ogni beat
            beatTimer.Microseconds = (long)((60000.0f / bpm) / 4.0f * 1000.0f);
        }

        private void BeatTimer_Elapsed(object sender, ProgressChangedEventArgs e)
        {
            //manda comando led
            com.WriteData(bbm.CreateBitMask(ReadLine()));
        }

        public void Start()
        {
            beatTimer.Start();
        }

        public void Stop()
        {
            beatTimer.Stop();
        }

        private string ReadLine()
        {
            string s = "0000"; //default: se é end of stream non ci sono note

            if (!sr.EndOfStream)
                s = sr.ReadLine();

            return s;
        }

    }
}
