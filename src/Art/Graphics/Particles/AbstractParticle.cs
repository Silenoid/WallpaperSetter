using System.Collections.Generic;
using SixLabors.ImageSharp;

namespace wallpaperSetter.Art.Graphics.Particles {
	public abstract class AbstractParticle : IDrawable {
		public abstract void draw(Image image, List<string> colorsStrings);
	}
}