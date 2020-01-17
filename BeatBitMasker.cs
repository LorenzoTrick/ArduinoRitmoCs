using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduBeats
{
    class BeatBitMasker
    {
        private int GetAddToCol(char adding, int multiplier)
        {
            switch (adding)
            {
                case '0':
                    return 0;
                case 'r':
                    return multiplier;
                case 'g':
                    return 2 * multiplier;
                case 'b':
                    return 3 * multiplier;
                default:
                    return -1;
            }
        }
        public char CreateBitMask(string beat)
        {
            int b = 0;

            char[] cols = beat.ToCharArray();

            int multiplier = 64;
            foreach (char col in cols)
            {
                b += GetAddToCol(col, multiplier);
                multiplier /= 4;
            }

            return (char)b;
        }
    }
}
