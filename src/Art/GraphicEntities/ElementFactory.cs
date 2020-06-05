using System;
using wallpaperSetter.Art.GraphicEntities.BigElements;
using wallpaperSetter.Art.GraphicEntities.SmallElements;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.GraphicEntities {
	public class ElementFactory {
		
		public static IElement getRendomBigElement() {
			switch (GenericUtils.random.Next(1)) {
				case 0: return new StarFrame();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static IElement getRendomSmallElement() {
			switch (GenericUtils.random.Next(2)) {
				case 0: return new AmebaParticles();
				case 1: return new Mimmolini();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}
	}
}