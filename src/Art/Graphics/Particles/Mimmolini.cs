﻿using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics.Particles {
	public class Mimmolini : AbstractParticle {
		public override void draw(Image image, List<string> colorsStrings) {
			var numPunti = 10;

			var options = new GraphicsOptions() {
				ColorBlendingMode = PixelColorBlendingMode.Multiply
			};
			IBrush brush = Brushes.Vertical(Color.ParseHex(colorsStrings[2]), Color.ParseHex(colorsStrings[1]));
			IPen pen = Pens.DashDot(Color.ParseHex(colorsStrings[1]), 5);

			for (var i = 0; i < numPunti; i++) {
				var size = GenericUtils.random.Next(10, 200);
				var poligono = new EllipsePolygon(
					GenericUtils.screenWidth * (GenericUtils.random.Next(-5, 105) / 100f),
					GenericUtils.screenHeight * (GenericUtils.random.Next(-5, 105) / 100f), 
					size,
					size
					);
				image.Mutate( imageProcessingContext => imageProcessingContext.Fill(brush, poligono).Draw(brush, 5f, poligono));
			}
		}
	}
}