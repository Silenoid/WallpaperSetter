using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.GraphicEntities.SmallElements {
	public class AmebaParticles : IElement {
		public void draw(Image image, List<string> colorsStrings) {
			var numClusters = 4;
			var numPunti = 6;
			
			IBrush brush = Brushes.BackwardDiagonal(Color.ParseHex(colorsStrings[2]), Color.Transparent);

			var pathBuilder = new PathBuilder();
			for (var j = 0; j < numClusters; j++) {
				var x = GenericUtils.screenWidth * (GenericUtils.random.Next(10, 90) / 100f);
				var y = GenericUtils.screenHeight * (GenericUtils.random.Next(10, 90) / 100f);
				for (var i = 0; i < numPunti; i++) {
					var size = GenericUtils.random.Next(40, 250);
					var poligono = new EllipsePolygon(
						x,
						y,
						size,
						size
					);
					image.Mutate( imageProcessingContext => imageProcessingContext.Fill(brush, poligono));
					x += GenericUtils.random.Next(-size, size);
					y += GenericUtils.random.Next(-size, size);
				}
			}
		}
	}
}