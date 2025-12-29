using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Game_Project_1.Extras
{
    internal class MusicPlayer
    {
        private static readonly int[] scale = new int[]
     {
        262, 294, 330, 349, 392, 440, 494, 523,
        587, 659, 698, 784, 880, 988
     };

        public static void PlayMelody()
        {
            int beatDuration = 500; // 120 BPM

            var notes = new (int pitch, int beat, int duration)[]
            {
            (2, 0, 1), (2, 2, 1), (4, 1, 2), (4, 5, 2),
            (3, 3, 1), (5, 3, 1), (6, 5, 1), (1, 6, 2)
            };

            for (int beat = 0; beat < 8; beat++)
            {
                bool notePlayed = false;

                foreach (var note in notes)
                {
                    if (note.beat == beat)
                    {
                        int pitchIndex = 13 - note.pitch;
                        int frequency = scale[pitchIndex];
                        Console.Beep(frequency, beatDuration * note.duration);
                        notePlayed = true;
                        break;
                    }
                }

                if (!notePlayed)
                    Thread.Sleep(beatDuration);
            }
        }



    }
}
