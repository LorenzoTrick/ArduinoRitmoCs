using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ArduBeats
{
    //classe che gestisce il punteggio (note prese o no...)
    class ScorePlayer
    {
        private SharedSerialPort com;
        private StreamReader sr;
        private ScoreSharer ss;

        private Tick MsTimer;

        private float bpm, offset;

        private float currentMs;

        private List<float>[] notes;
        private List<char>[] types;

        private bool[] isGreenOn;
        private bool[] isBlueOn;
        public bool fillDone { get; set; }

        public ScorePlayer(string filePath)
        {
            com = SharedSerialPort.StartInstance();
            sr = new StreamReader(filePath);
            ss = ScoreSharer.StartInstance();

            float.TryParse(ReadLine(), out bpm);
            float.TryParse(ReadLine(), out offset);

            notes = new List<float>[4];
            types = new List<char>[4];
            isGreenOn = new bool[4];
            isBlueOn = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                notes[i] = new List<float>();
                types[i] = new List<char>();
                isGreenOn[i] = false;
                isBlueOn[i] = false;
            }

            //timer da 1000us = 1ms
            MsTimer = new Tick(MsTimer_Elapsed);
            MsTimer.Microseconds = 1000L;

            fillDone = false;
            FillLists();

            //parte da - (warmup + offset)
            currentMs = - (((60000.0f / bpm) / 4.0f * 20.0f + offset));
            MsTimer.Start();
        }

        private void ButtonPressCheck(int line)
        {
            //é una nota rossa?
            if (types[line][0] == 'r')
                SetNoteScore(notes[line], types[line]);

            //é una nota verde iniziata?
            else if (types[line][0] == 'g')
                isGreenOn[line] = true;

            //é una nota blu iniziata?
            //NOTA BLU: hitta in tempo all'inizio e alla fine, ma nel mezzo quante volte vuoi (+1 perfect ogni volta)
            else if (types[line][0] == 'b' && !isBlueOn[line])
            {
                isBlueOn[line] = true;
                SetNoteScore(notes[line], types[line]);
            }

            //é un clic a caso dentro una nota blu?
            else if (isBlueOn[line] && currentMs < 150.0f + notes[line][0])
                    ss.perfectCount++;

            //se siamo arrivati qui, é una nota blu finita!
            else 
            {
                isBlueOn[line] = false;
                SetNoteScore(notes[line], types[line]);
            }
        }

        private void ButtonReleaseCheck(int line)
        {
            //é una nota verde rilasciata?
            if (isGreenOn[line] == true)
            {
                SetNoteScore(notes[line], types[line]);
                isGreenOn[line] = false;
            }
        }

        private void MsTimer_Elapsed(object sender, ProgressChangedEventArgs e)
        {
            currentMs++;
            char press = com.ReadData();
            if (press != '\0')
            {
                switch (press)
                {
                    case 'A':
                        ButtonPressCheck(0);
                        break;
                    case 'B':
                        ButtonPressCheck(1);
                        break;
                    case 'C':
                        ButtonPressCheck(2);
                        break;
                    case 'D':
                        ButtonPressCheck(3);
                        break;
                    case 'a':
                        ButtonReleaseCheck(0);
                        break;
                    case 'b':
                        ButtonReleaseCheck(1);
                        break;
                    case 'c':
                        ButtonReleaseCheck(2);
                        break;
                    case 'd':
                        ButtonReleaseCheck(3);
                        break;
                }

            }
            else
            {
                //controlla se si sono missate note perché non premute
                for (int i = 0; i < 4; i++)
                {
                    if (notes[i].Count != 0)
                        if (currentMs > 500.0f + notes[i][0])
                            SetNoteScore(notes[i], types[i]);
                }
            }
        }

        private void FillLists()
        {
            //default: le prime 2 righe sono giá state lette
            float perfectMs = 0;

            bool[] greenActive = { false, false, false, false };
            bool[] blueActive = { false, false, false, false };

            while (!sr.EndOfStream)
            {
                char[] line = sr.ReadLine().ToCharArray();
                for (int i = 0; i < 4; i++)
                {
                    if (line[i] == 'r' && !greenActive[i] && !blueActive[i])
                    {
                        notes[i].Add(perfectMs);
                        types[i].Add('r');
                    }

                    //se inizia o finisce una linea verde
                    if ((line[i] == 'g' && !greenActive[i]) || (line[i] != 'g' && greenActive[i]))
                    {
                        greenActive[i] = !(greenActive[i]);
                        notes[i].Add(perfectMs);
                        types[i].Add('g');
                    }

                    //se inizia o finisce una linea blue
                    if ((line[i] == 'b' && !blueActive[i]) || (line[i] != 'b' && blueActive[i]))
                    {
                        blueActive[i] = !(blueActive[i]);
                        notes[i].Add(perfectMs);
                        types[i].Add('b');
                    }
                }

                perfectMs += (60000.0f / bpm) / 4.0f;
            }

            fillDone = true;
            sr.Close();
        }

        public void Start()
        {
            MsTimer.Start();
        }

        private string ReadLine()
        {
            string s = "0000"; //default: se é end of stream non ci sono note (FAILSAFE)

            if (!sr.EndOfStream)
                s = sr.ReadLine();

            return s;
        }

        private void SetNoteScore(List<float> line, List<char> type)
        {
            //sotto i -500ms: clic a caso, non contare

            //miss: -500/-150 ms escluso o da +150 ms escluso in poi
            if ((currentMs >= -500.0f + line[0] && currentMs < -150.0f + line[0]) || currentMs > 150.0f + line[0])
                ss.missCount++;

            //scarso: -150/-100 ms escluso o +100/+150 ms incluso
            else if ((currentMs >= -150.0f + line[0] && currentMs < -100.0f + line[0]) || (currentMs > 100.0f + line[0] && currentMs <= 150.0f + line[0]))
                ss.badCount++;

            //buono: -100/-50 ms escluso o +50/+100 ms incluso
            else if ((currentMs >= -100.0f + line[0] && currentMs < -50.0f + line[0]) || (currentMs > 50.0f + line[0] && currentMs <= 100.0f + line[0]))
                ss.greatCount++;

            //perfetto: -50/+50 ms inclusi 
            else if (currentMs >= -50.0f + line[0] && currentMs <= 50.0f + line[0])
                ss.perfectCount++;

            //poi cancella nota finita
            line.RemoveAt(0);
        }

        public void Stop()
        {
            MsTimer.Stop();
        }
    }
}
