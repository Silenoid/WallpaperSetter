using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics.DetailsElements {
	public class Righini : AbstractDetailsElement {

		protected override void drawDetails(Image image, List<string> colorsStrings) {
			var numClusters = GenericUtils.random.Next(1, 4);

			IBrush brush = GenericUtils.choose(
				Brushes.BackwardDiagonal(Color.ParseHex(colorsStrings[2]), Color.Transparent),
				Brushes.ForwardDiagonal(Color.ParseHex(colorsStrings[2]), Color.ParseHex(colorsStrings[1]))
				);
			
			var pathBuilder = new PathBuilder();
			for (var j = 0; j < numClusters; j++) {
				var x = GenericUtils.screenSize.Width * (GenericUtils.random.Next(100) / 100f);
				var y = GenericUtils.screenSize.Height * (GenericUtils.random.Next(100) / 100f);
				var numPoints = GenericUtils.random.Next(1, 7);
				
				for (var i = 0; i < numPoints; i++) {
					var size = GenericUtils.random.Next(40, 350);
					var ellipsePolygon = new EllipsePolygon(
						x,
						y,
						size,
						size
					);
					image.Mutate( imageProcessingContext => imageProcessingContext.Fill(brush, ellipsePolygon));

					x += GenericUtils.random.Next(-size, size);
					y += GenericUtils.random.Next(-size, size);
				}
			}
		}
	}
}