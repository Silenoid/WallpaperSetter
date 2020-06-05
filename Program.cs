﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using wallpaperSetter.Utilities;

namespace wallpaperSetter {
    class Program {
        private static string startupPath = Application.StartupPath;

        static void Main(string[] args) {
            
            //Welcome
            PrinterUtils.printWelcome(args);
            
            //Selezione modalità
            if (args.Length > 0) {
                switch (args[0]) {
                    
                    case "-h": case "--help":
                        PrinterUtils.printHelp();
                        break;
                    
                    case "-gen":
                        if (args.Length == 1) {
                            GearWallpaper.generateArt();
                        } else if (args.Length == 4) {
                            var colorsStrings = new List<string>() {args[1], args[2], args[3]};
                            GearWallpaper.generateArt(colorsStrings);
                        } else {
                            Console.WriteLine("Wrong number of passed arguments");
                            PrinterUtils.printHelp();
                        }
                        break;
                    
                    case "-web":
                        GearWallpaper.downloadArt(new Uri("https://picsum.photos/" + GenericUtils.screenWidth + "/" + GenericUtils.screenHeight), GearWallpaper.Style.Centered);
                        break;
                    
                    default:
                        Console.WriteLine("Command not recognized");
                        PrinterUtils.printHelp();
                        break;
                }
            }
        }
    }
}
