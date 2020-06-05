using System;
using System.IO;
using Newtonsoft.Json;

namespace wallpaperSetter.Utilities {
    public class FileSystemUtils {
        
        public static string rootPath = Path.Combine(Path.GetTempPath(), "WallpaperSetter");
        public static string settingsPath = Path.Combine(rootPath, "settings.json");
        public static string webFilePath = Path.Combine(rootPath, "WebWallpaper.png");
        public static string genFilePath = Path.Combine(rootPath, "GenWallpaper.png");

        /// <summary>
        /// Reads an object instance from an Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Json file.</returns>
        public static T readFromJsonFile<T>(string filePath) where T : new() {
            TextReader reader = null;
            try {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                Console.WriteLine("Loaded settings file in: " + filePath);
                return JsonConvert.DeserializeObject<T>(fileContents);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return new T();
            } finally {
                if (reader != null)
                    reader.Close();
            }
        }

        /// <summary>
        /// Writes the given object instance to a Json file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [JsonIgnore] attribute.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void writeToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new() {
            TextWriter writer = null;
            try {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
                Console.WriteLine("Saved settings file in: " + filePath);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}