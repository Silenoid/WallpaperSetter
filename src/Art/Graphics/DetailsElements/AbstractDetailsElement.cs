using System.Collections.Generic;
using SixLabors.ImageSharp;
using wallpaperSetter.Art.Structures;

namespace wallpaperSetter.Art.Graphics.DetailsElements {
	public abstract class AbstractDetailsElement : IDrawable {
		
		protected Cluster cluster;

		protected AbstractDetailsElement(Cluster cluster) {
			this.cluster = cluster;
		}

		public void draw(Image image, List<string> colorsStrings) {
			drawDetails(image, colorsStrings);
		}

		protected abstract void drawDetails(Image image, List<string> colorsStrings);
	}
}