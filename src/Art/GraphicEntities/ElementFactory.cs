using wallpaperSetter.Art.GraphicEntities.BigElements;
using wallpaperSetter.Art.GraphicEntities.SmallElements;

namespace wallpaperSetter.Art.GraphicEntities {
	public class ElementFactory {
		public static IElement getRendomBigElement() {
			return new StarFrame();
		}

		public static IElement getRendomSmallElement() {
			return new AmebaParticles();
		}
	}
}