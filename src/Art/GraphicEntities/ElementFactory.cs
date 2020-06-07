using System;
using wallpaperSetter.Art.GraphicEntities.DetailsElements;
using wallpaperSetter.Art.GraphicEntities.MacroElements;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.GraphicEntities {
	public class ElementFactory {
		
		public static IElement getRandomMacroElement() {
			switch (GenericUtils.random.Next(1)) {
				case 0: return new StarFrame();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static IElement getRandomDetailsElement() {
			return new Mimmolini();
			switch (GenericUtils.random.Next(2)) {
				case 0: return new AmebaParticles();
				case 1: return new Mimmolini();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}
	}
}