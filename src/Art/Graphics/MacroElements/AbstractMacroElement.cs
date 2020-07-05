using System.Collections.Generic;
using SixLabors.ImageSharp;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics.MacroElements {
	public abstract class AbstractMacroElement : IDrawable {
		private IDrawable detailElement = ArtFactory.getRandomDetailsElement();
		
		public abstract void draw(Image image, List<string> colorsStrings);
	}
}