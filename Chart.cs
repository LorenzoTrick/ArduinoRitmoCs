using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ArduBeats
{
    /**
     * @class Chart
     * @brief Superclasse che gestisce la chart (note + musica + timing) come insieme
     */
    class Chart
    {
        private bool active;
        private bool isValid;
        private float bpm;
        private float offset;
        private ScorePlayer score;
        private NotesPlayer notes;
        private SoundPlayer music;
        private Tick musicTimer, notesTimer;
        private bool musicStarted, notesStarted;
        public Chart(DirectoryInfo chartPath)
        {
            active = true;
            isValid = true;
            musicStarted = false;
            notesStarted = false;
            FileInfo[] songPath = chartPath.GetFiles("*.wav");
            try
            {
                music = new SoundPlayer(chartPath.FullName + "/" + songPath[0].Name);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No canzone!");
                isValid = false;
            }

            FileInfo[] notePath = chartPath.GetFiles("*.beats");
            try
            {
                notes = new NotesPlayer(chartPath.FullName + "/" + notePath[0].Name);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No note!");
                isValid = false;
            }

            score = new ScorePlayer(chartPath.FullName + "/" + notePath[0].Name);
        }

        public void Start()
        {
            if (isValid)
            {
                //SCORE: parte subito
                score.Start();

                //aspetta che lo ScorePlayer abbia finito di salvarsi le note (ci mette un po' di millisecondi)
                while (!score.fillDone) ;

                //trova bpm e offset da file
                bpm = notes.bpm;
                offset = notes.offset;

                //MUSICA: fa partire la musica dopo 20 beat (warmup)
                musicTimer = new Tick(MusicStart);
                musicTimer.Microseconds = (long)(((60000.0f / bpm) / 4.0f) * 20.0f * 1000.0f);
                musicTimer.Start();

                //NOTE: aspetta 20 beat + offset - 16 beat (fino a inizio led) = offset + 4 beat
                try
                {
                    notesTimer = new Tick(NotesStart);
                    notesTimer.Microseconds = (long)(offset + ((60000.0f / bpm) / 4.0f) * 4.0f * 1000.0f);
                    notesTimer.Start();
                }
                catch(Exception)
                {
                    Console.WriteLine("No offset!");
                }

            }
        }

        private void MusicStart(object sender, ProgressChangedEventArgs e)
        {
            if (active && !musicStarted)
            {
                music.Play();
                musicStarted = true;
            }

        }

        private void NotesStart(object sender, ProgressChangedEventArgs e)
        {
            if (active && !notesStarted)
            {
                notes.Start();
                notesStarted = true;
            }
        }

        public void Stop()
        {
            active = false;
            if (isValid)
            {
                music.Stop();
                notes.Stop();
                score.Stop();
            }
        }
    }
}
