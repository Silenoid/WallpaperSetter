using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace wallpaperSetter.Art.Graphics.DetailsElements {
	public abstract class AbstractDetailsElement : IDrawable {
		public void draw(Image image, List<string> colorsStrings) {
			drawDetails(image, colorsStrings);
		}

		protected abstract void drawDetails(Image image, List<string> colorsStrings);
	}
}