using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using wallpaperSetter.Art.Structures;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics.DetailsElements {
	public class Mimmolini : AbstractDetailsElement {

		public Mimmolini(Cluster cluster) : base(cluster) {
			this.cluster = cluster;
		}

		protected override void drawDetails(Image image, List<string> colorsStrings) {
			var options = new GraphicsOptions() {
				ColorBlendingMode = PixelColorBlendingMode.Multiply
			};
			IBrush brush = new PatternBrush(Color.ParseHex(colorsStrings[2]), Color.ParseHex(colorsStrings[1]), ArtFactory.getRandomPattern());
			IPen pen = Pens.DashDot(Color.ParseHex(colorsStrings[1]), 5);

			foreach (var points in cluster.calculatePositions()) {
				var size = GenericUtils.random.Next(10, 200);
				cluster.polygon = new EllipsePolygon(
					GenericUtils.screenSize.Width * (GenericUtils.random.Next(-5, 105) / 100f),
					GenericUtils.screenSize.Height * (GenericUtils.random.Next(-5, 105) / 100f), 
					size,
					size
				);
				image.Mutate( imageProcessingContext => imageProcessingContext.Fill(brush, cluster.polygon).Draw(brush, 5f, cluster.polygon));
			}
		}
	}
}