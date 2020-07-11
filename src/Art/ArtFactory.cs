using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using wallpaperSetter.Art.Graphics.DetailsElements;
using wallpaperSetter.Art.Graphics.MacroElements;
using wallpaperSetter.Art.Structures;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art {
	public static class ArtFactory {
		
		public static AbstractMacroElement getRandomMacroElement() {
			switch (GenericUtils.random.Next(1)) {
				case 0: return new StarFrame();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static AbstractDetailsElement getRandomDetailsElement() {
			return new Mimmolini(new Cluster());
			switch (GenericUtils.random.Next(2)) {
				case 0: return new Mimmolini(new Cluster());
				case 1: return new Righini(new Cluster());
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static Cluster getRandomCluster() {
			return new Cluster(getRandomPolygon(), GenericUtils.random.Next(1, 5), Disposition.Random);
		}

		public static IPath getRandomPolygon() {
			var x = GenericUtils.screenSize.Width * (GenericUtils.random.Next(-5, 105) / 100f);
			var y = GenericUtils.screenSize.Height * (GenericUtils.random.Next(-5, 105) / 100f);
			var sizeFactor = (int) Math.Sqrt(Math.Pow(GenericUtils.screenSize.Width, 2) + Math.Pow(GenericUtils.screenSize.Height, 2));
			var size = GenericUtils.random.Next(10, 200);
			switch (GenericUtils.random.Next(5)) {
				
				case 0:
					return new EllipsePolygon(
						x,
						y,
						size,
						size
					);

				case 1:
					var spikes = GenericUtils.random.Next(3, 7);
					float innerRad = GenericUtils.random.Next(sizeFactor / 6, sizeFactor / 2);
					float outerRad = GenericUtils.random.Next(sizeFactor / 6, sizeFactor / 2);
					return new Star(
						x,
						y,
						prongs: spikes,
						innerRadii: innerRad,
						outerRadii: outerRad
					);

				case 2:
					return new RectangularPolygon(
						x,
						y,
						size * GenericUtils.random.Next((int) (sizeFactor * 0.25)),
						size * GenericUtils.random.Next((int) (sizeFactor * 0.25))
					);
				
				case 3:
					return new Polygon(
						new ILineSegment[] {
							new LinearLineSegment(new PointF(0, 0), new PointF(0, 0)),
							new LinearLineSegment(new PointF(0, 0), new PointF(0, 0))
						}
					);
				
				case 4:
					return new ComplexPolygon(
						new IPath[] {
							new EllipsePolygon(
								x,
								y,
								size,
								size
							),
							new EllipsePolygon(
								x,
								y,
								size,
								size
							)
						}
					);
				
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static IBrush getRandomBrush(Color color1, Color color2) {
			return new PatternBrush(color1, color2, getRandomPattern());
		}

		public static bool[,] getRandomPattern() {
			return new bool[4, 4] {
				{false, true, false, false},
				{false, false, true, false},
				{false, false, true, false},
				{false, true, false, false}
			};
		}
	}
}