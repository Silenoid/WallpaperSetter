using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace wallpaperSetter.Utilities {
    public class GenericUtils {
        public static Random random = new Random();
        public static int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        public static int screenHeight = Screen.PrimaryScreen.Bounds.Height;

        public static void shuffleList<T>(List<T> list) {
            var n = list.Count;
            while (n > 1) {
                n--;
                var k = random.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        
        public static T choose<T>(params T[] args) {
            if (args.Length == 0)
                throw new Exception("Choosing on a empty array");
            return args[random.Next(args.Length)];
        }

        public static float norma(float x, float y) {
            return 0;
        }
    }
}