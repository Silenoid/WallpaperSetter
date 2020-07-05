using System.Collections.Generic;
using SixLabors.ImageSharp;
using wallpaperSetter.Art.Graphics.DetailsElements;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics.MacroElements {
	public abstract class AbstractMacroElement : IDrawable {
		
		protected AbstractDetailsElement detailElement = ArtFactory.getRandomDetailsElement();
		
		public abstract void draw(Image image, List<string> colorsStrings);
	}
}