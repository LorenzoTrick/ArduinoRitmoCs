using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduBeats
{
    class ScoreSharer
    {
        private static ScoreSharer _instance;

        public int perfectCount { get; set; }
        public int greatCount { get; set; }
        public int badCount { get; set; }
        public int missCount { get; set; }
        public static ScoreSharer StartInstance()
        {
            if (_instance == null)
            {
                _instance = new ScoreSharer();
            }

            return _instance;
        }
        private ScoreSharer()
        {
            perfectCount = 0;
            greatCount = 0;
            badCount = 0;
            missCount = 0;
        }

        public float GetAccuracy()
        {
            if (perfectCount + greatCount + badCount + missCount != 0)
                return (perfectCount + 0.5f * greatCount + 0.2f * badCount) / (perfectCount + greatCount + badCount + missCount) * 100;
            else
                return 0.0f;
        }

        public void Reset()
        {
            perfectCount = 0;
            greatCount = 0;
            badCount = 0;
            missCount = 0;
        }

    }
}
