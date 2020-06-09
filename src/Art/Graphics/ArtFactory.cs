using System;
using wallpaperSetter.Art.Graphics.DetailsElements;
using wallpaperSetter.Art.Graphics.Paintings;
using wallpaperSetter.Art.Graphics.Particles;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics {
	public class ElementFactory {
		
		public static IElement getRandomMacroElement() {
			switch (GenericUtils.random.Next(1)) {
				case 0: return new StarFrame();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static AParticle getRandomParticleElement() {
			switch (GenericUtils.random.Next(2)) {
				case 0: return new AmebaParticles();
				case 1: return new Mimmolini();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}
	}
}