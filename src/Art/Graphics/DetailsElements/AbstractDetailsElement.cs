using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace wallpaperSetter.Art.Graphics.DetailsElements {
	public abstract class AbstractDetailsElement : IDrawable {
		public abstract void draw(Image image, List<string> colorsStrings);
	}
}