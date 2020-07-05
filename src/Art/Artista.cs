using System.Collections.Generic;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using wallpaperSetter.Art.Graphics;

namespace wallpaperSetter.Art {
    public class Artista {
        public void invent(Image<Rgba32> image, List<string> colorsStrings) {
            image.Mutate(imageProcessingContext => imageProcessingContext.Fill(Color.ParseHex(colorsStrings[0])));
            ArtFactory.getRandomMacroElement().draw(image, colorsStrings);
        }
    }
}