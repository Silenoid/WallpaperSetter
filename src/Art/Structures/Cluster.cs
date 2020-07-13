using System;
using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using wallpaperSetter.Utilities;

namespace wallpaperSetter.Art.Structures {
	
	public enum Disposition {
		Random,
		Ameba,
		Circle,
		Line,
		Corner
	}
	
	public class Cluster {
		public IPath polygon;
		public int particlesNumber;
		public Disposition disposition;
		
		public Cluster() {
			this.polygon = ArtFactory.getRandomPolygon();
			this.particlesNumber = GenericUtils.random.Next(2,10);
			this.disposition = GenericUtils.choose(
				Disposition.Random,
				Disposition.Ameba,
				Disposition.Circle,
				Disposition.Line,
				Disposition.Corner);
		}

		public Cluster(IPath polygon, int particlesNumber, Disposition disposition) {
			this.polygon = polygon;
			this.particlesNumber = particlesNumber;
			this.disposition = disposition;
		}

		public List<PointF> calculatePositions() {
			var points = new List<PointF>();
			var point = new PointF(0,0);
			ConsoleUtils.printDebug("Particle numbers: " + particlesNumber);
			for (var i = 0; i < particlesNumber; i++) {
				switch (disposition) {
					case Disposition.Random:
						ConsoleUtils.printDebug("Random disposition");
						point.X = GenericUtils.screenSize.Width * (float) GenericUtils.getRandomDisposition(0f, 1f, 0.05f);
						point.Y = GenericUtils.screenSize.Height * (float) GenericUtils.getRandomDisposition(0f, 1f, 0.05f);
						break;
					case Disposition.Ameba:
						break;
					case Disposition.Circle:
						break;
					case Disposition.Line:
						break;
					case Disposition.Corner:
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				ConsoleUtils.printDebug("Point made: " + point.ToString());
				points.Add(point);
			}
			return points;
		}
	}
}