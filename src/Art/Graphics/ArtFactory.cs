using System;
using wallpaperSetter.Art.Graphics.DetailsElements;
using wallpaperSetter.Art.Graphics.MacroElements;
using wallpaperSetter.Art.Graphics.Particles;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Graphics {
	public class ArtFactory {
		
		public static IDrawable getRandomMacroElement() {
			switch (GenericUtils.random.Next(1)) {
				case 0: return new StarFrame();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}
		
		public static AbstractParticle getRandomDetailsElement() {
			switch (GenericUtils.random.Next(2)) {
				case 0: return new AmebaParticles();
				case 1: return new Mimmolini();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}

		public static AbstractParticle getRandomParticleElement() {
			switch (GenericUtils.random.Next(2)) {
				case 0: return new AmebaParticles();
				case 1: return new Mimmolini();
				default: throw new NotImplementedException("There is no graphic object assigned to this case");
			}
		}
	}
}