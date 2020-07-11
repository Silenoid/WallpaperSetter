using System;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics.MacroElements {
	public class StarFrame : AbstractMacroElement {
		public override void drawMacro(Image image, List<string> colorsStrings) {
			float x = 0;
			float y = 0;
			var numStelle = (float) GenericUtils.random.Next(1, 5);

			switch (GenericUtils.random.Next(4)) {
				case 0:
					x = GenericUtils.screenSize.Width;
					y = GenericUtils.screenSize.Height / numStelle;
					break;
				case 1:
					x = GenericUtils.screenSize.Width / numStelle;
					y = 0f;
					break;
				case 2:
					x = 0f;
					y = GenericUtils.screenSize.Height / numStelle;
					break;
				case 3:
					x = GenericUtils.screenSize.Width / numStelle;
					y = GenericUtils.screenSize.Height;
					break;
			}

			for (var i = 0; i < numStelle; i++) {
				var sizeFactor = (int) Math.Sqrt(Math.Pow(GenericUtils.screenSize.Width, 2) + Math.Pow(GenericUtils.screenSize.Height, 2));
				float innerRad = GenericUtils.random.Next(sizeFactor / 6, sizeFactor / 2);
				float outerRad = GenericUtils.random.Next(sizeFactor / 6, sizeFactor / 2);
				var spikes = GenericUtils.random.Next(3, 7);
				Console.WriteLine("Drawing Stella: innerRad " + innerRad + ", outerRad " + outerRad + ", spikes " + spikes);
				IPath stella = new Star(x, y, prongs: spikes, innerRadii: innerRad, outerRadii: outerRad);
				image.Mutate(imageProcessingContext => imageProcessingContext.Fill(Color.ParseHex(colorsStrings[1]), stella));
				x *= Convert.ToSingle(1.5f + GenericUtils.random.NextDouble() * 0.4f);
				y *= Convert.ToSingle(1.5f + GenericUtils.random.NextDouble() * 0.4f);
			}
		}
	}
}