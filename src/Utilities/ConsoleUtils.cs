using System;
using System.Numerics;

namespace wallpaperSetter.Utilities {
	public class ConsoleUtils {
		public static void printHelp() {
			printBox("ACCEPTED ARGUMENTS", new[] {
				"-h\t\t\t\tPrints help menu",
				"-gen\t\t\t\tGenerate random art and set as wallpaper",
				"-gen #color1 #color2 #color3\tGenerate random art with given palette and set wallpaper",
				"-web\t\t\t\tSet random online images as wallpaper"
			});
		}

		public static void printBox(string title, string[] lines) {
			Console.WriteLine("\n╔══ " + title.ToUpper() + " ═════════════════════");
			foreach (var line in lines) {
				Console.WriteLine("║ " + line);
			}

			Console.WriteLine("╚═══════════════════════════════════════════════\n");
		}

		public static void printWelcome(string[] args) {
			Console.WriteLine("\n\n╔══ Applicazione della sfaccimma partita! ═══════");
			for (var i = 0; i < args.Length; i++) {
				Console.WriteLine("║ args[" + i + "]: " + args[i]);
			}
			Console.WriteLine("║ Vector hardware acceleration: " + Vector.IsHardwareAccelerated);
			Console.WriteLine("║ Dimenioni Schermo: " + GenericUtils.screenSize.Width + ", " + GenericUtils.screenSize.Height);
			Console.WriteLine("╚═══════════════════════════════════════════════\n");
		}

		public static void printDebug(string msg) {
			var prevColor = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine(msg);
			Console.ForegroundColor = prevColor;
		}
	}
}