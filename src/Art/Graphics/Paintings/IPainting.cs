using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace wallpaperSetter.Art.Graphics.Paintings {
	public interface IElement {
		void draw(Image image, List<string> colorsStrings);
	}
}