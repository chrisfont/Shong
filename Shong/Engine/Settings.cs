using System.IO;
using Newtonsoft.Json;

using Shong.Engine.Input;
using Shong.Engine.Video;

namespace Shong.Engine
{
    class Settings
    {
        [JsonIgnore]
        public string FilePath = null;

        public InputSettings Input;
        public VideoSettings Video;

        public Settings()
        {
            // No file given, initialize to defaults
            Input = new InputSettings();
            Video = new VideoSettings();
        }

        public Settings(string filePath)
        {
            // File path given, let's load!
            FilePath = ExtCheck(filePath);

            if (File.Exists(FilePath))
            {
                Load();
            }
            else
            {
                // Settings doesn't exist yet, so initialize to defaults and create
                Input = new InputSettings();
                Video = new VideoSettings();

                Save();
            }
        }

        public void Load()
        {
            // We can only load if FilePath is set
            if (FilePath != null && File.Exists(FilePath))
            {
                var tempSetting = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(FilePath));

                Input = tempSetting.Input;
                Video = tempSetting.Video;
            }
            else
            {
                // This is an error, we cannot load from a non-existant file
                var error = FilePath != null ? "Attempted to load settings with no FilePath set" : "Attempted to load settings from a non-existant file.";
                Log.Instance.LogMsg(LogType.Error, error);
            }
        }

        public void Save()
        {
            // We can only save if FilePath is set
            if (FilePath != null)
            {
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings()));
            }
            else
            {
                Log.Instance.LogMsg(LogType.Warning, "Settings save called with no FilePath set");
            }
        }

        // Helper function for FilePath extension
        private static string ExtCheck(string path)
        {
            var extension = Path.GetExtension(path);

            if (extension != null && extension.ToLower().Equals(".json")) return path;

            return path + ".json";
        }
    }
}
