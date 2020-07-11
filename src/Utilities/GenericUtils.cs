using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SixLabors.ImageSharp;

namespace wallpaperSetter.Utilities {
	public class GenericUtils {
		public static Random random = new Random();

		public static SizeF screenSize = new SizeF(
			Screen.PrimaryScreen.Bounds.Width,
			Screen.PrimaryScreen.Bounds.Height);

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
				throw new Exception("Can't choose on zero args");
			return args[random.Next(args.Length)];
		}

		public static double norma(float x, float y) {
			return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(x, 2));
		}

		public static double getRandomDisposition(float minValue, float maxValue, float margin = 0, float holeValue = 0) {
			if (minValue > maxValue) throw new Exception("minValue " + minValue + " is greater than maxValue " + maxValue);
			if (holeValue < 0) throw new Exception("holeValue " + holeValue + " cannot be negative");
			var lenght = Math.Abs(minValue - maxValue);
			var center = lenght * 0.5;
			if (holeValue >= (lenght * 0.5) + margin) throw new Exception("holeValue " + holeValue + " is greater than the possible range " + ((lenght * 0.5) + margin));
			return choose(
				GenericUtils.random.NextDouble() * Math.Abs(center - holeValue - margin) - margin,
				GenericUtils.random.NextDouble() * Math.Abs(center - holeValue - margin) + center + holeValue
			);
		}
	}
}