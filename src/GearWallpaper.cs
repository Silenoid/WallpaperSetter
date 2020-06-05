using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using wallpaperSetter.Art;
using wallpaperSetter.Utilities;
using Image = System.Drawing.Image;

namespace wallpaperSetter {
    public class GearWallpaper {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private const int SpiSetdeskwallpaper = 20;
        private const int SpifUpdateinifile = 0x01;
        private const int SpifSendwininichange = 0x02;
        
        private static RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        private static SettingsFile settingsFile = FileSystemUtils.readFromJsonFile<SettingsFile>(FileSystemUtils.settingsPath);

        public enum Style : int {
            Tiled,
            Centered,
            Stretched
        }

        public static void downloadArt(Uri uri, Style style) {
            var webStream = new WebClient().OpenRead(uri.ToString());
            var image = Image.FromStream(webStream ?? throw new Exception("Web stream problem"));
            image.Save(FileSystemUtils.webFilePath, ImageFormat.Png);
            
            Console.WriteLine("Saved image in " + FileSystemUtils.webFilePath);
            Process.Start(FileSystemUtils.rootPath);

            setImageAsWallpaper(FileSystemUtils.webFilePath, style);
        }

        public static void generateArt() {
            if (settingsFile.colors != null && settingsFile.colors.Count != 0) 
                generateArt(settingsFile.colors);
            else {
                Console.WriteLine("Settings file not found. Specify colors for the first time!");
            }
        }

        public static void generateArt(List<string> colorsStrings) {
            settingsFile.colors = colorsStrings;
            FileSystemUtils.writeToJsonFile(FileSystemUtils.settingsPath, settingsFile);

            using (var image = new Image<Rgba32>(GenericUtils.screenWidth, GenericUtils.screenHeight)) {
                var artista = new Artista();
                artista.invent(image, colorsStrings);
                
                using (var inputStream = new FileStream(FileSystemUtils.genFilePath, FileMode.Create)) {
                    image.SaveAsPng(inputStream);
                    Console.WriteLine("Saved image in " + FileSystemUtils.genFilePath);
                }
            }

            setImageAsWallpaper(FileSystemUtils.genFilePath, Style.Centered);
            Process.Start(FileSystemUtils.rootPath);
        }

        public static void setImageAsWallpaper(string filePath, Style style) {
            switch (style) {
                case Style.Tiled:
                    registryKey?.SetValue(@"WallpaperStyle", 1.ToString());
                    registryKey?.SetValue(@"TileWallpaper", 1.ToString());
                    break;
                case Style.Centered:
                    registryKey?.SetValue(@"WallpaperStyle", 1.ToString());
                    registryKey?.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case Style.Stretched:
                    registryKey?.SetValue(@"WallpaperStyle", 2.ToString());
                    registryKey?.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(style), style, null);
            }

            SystemParametersInfo(SpiSetdeskwallpaper,
                0,
                filePath,
                SpifUpdateinifile | SpifSendwininichange);
        }
    }
}