using System.Collections.Generic;
using SixLabors.ImageSharp;
using wallpaperSetter.Art.Graphics.DetailsElements;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics.MacroElements {
	public abstract class AbstractMacroElement : IDrawable {
		
		protected AbstractDetailsElement detailElement = ArtFactory.getRandomDetailsElement();

		public void draw(Image image, List<string> colorsStrings) {
			drawMacro(image, colorsStrings);
			if (GenericUtils.choosePercent(70)) {
				detailElement.draw(image, colorsStrings);
			}
		}
		
		public abstract void drawMacro(Image image, List<string> colorsStrings);
	}
}