using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using wallpaperSetter.Art.Graphics.DetailsElements;
using wallpaperSetter.Art.Graphics.MacroElements;
using wallpaperSetter.Art.Structures;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art {
	public class ArtFactory {
		
		public static AbstractMacroElement getRandomMacroElement() {
			switch (GenericUtils.random.Next(1)) {
				case 0: return new StarFrame();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}
		
		public static AbstractDetailsElement getRandomDetailsElement() {
			return new Mimmolini();
			switch (GenericUtils.random.Next(2)) {
				case 0: return new Mimmolini();
				case 1: return new Righini();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static Cluster getRandomCluster() {
			return new Cluster(getRandomPolygon(), GenericUtils.random.Next(1,5));
		}

		public static Polygon getRandomPolygon() {
			switch (GenericUtils.random.Next(2)) {
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static IBrush getRandomBrush(Color color1, Color color2) {
			return new PatternBrush(color1, color2, getRandomPattern());
		}

		public static bool[,] getRandomPattern() {
			return new bool[4,4] {
				{false,true,false,false},
				{false,false,true,false},
				{false,false,true,false},
				{false,true,false,false}
			};
		}
	}
}