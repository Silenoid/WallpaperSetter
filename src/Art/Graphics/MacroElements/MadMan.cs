using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;

namespace wallpaperSetter.Art.Graphics.MacroElements {
	public class MadMan : AbstractMacroElement {
		public override void drawMacro(Image image, List<string> colorsStrings) {
			var randomCluster = ArtFactory.getRandomCluster();
			
			foreach (var point in randomCluster.calculatePositions()) {
				var brush = new SolidBrush(Color.ParseHex(colorsStrings[1]));
				
				image.Mutate(imageProcessingContext => {
					imageProcessingContext.Fill(
						brush,
						randomCluster.polygon);
				});
			}
		}
	}
}