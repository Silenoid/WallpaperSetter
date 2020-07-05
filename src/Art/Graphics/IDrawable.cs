using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace wallpaperSetter.Art.Graphics {
	public interface IDrawable {
		void draw(Image image, List<string> colorsStrings);
	}
}