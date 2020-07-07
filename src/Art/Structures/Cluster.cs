using SixLabors.ImageSharp.Drawing;

namespace wallpaperSetter.Art.Structures {
	public enum Disposition {
		RANDOM,
		AMEBA,
		CIRCLE,
		LINE
	}
	
	public class Cluster {
		public Polygon polygon;
		public int particlesNumber;
		public Disposition disposition;

		public Cluster(Polygon polygon, int particlesNumber, Disposition disposition = Disposition.RANDOM) {
			this.polygon = polygon;
			this.particlesNumber = particlesNumber;
			this.disposition = disposition;
		}
	}
}