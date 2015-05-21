namespace Shong.Engine.Video
{
    enum VSyncMode
    {
        On,
        Off
    }

    class VideoResolution
    {
        public int Height;
        public int Width;

        public VideoResolution()
        {
            Width  = 800;
            Height = 640;
        }

        public VideoResolution(int width, int height)
        {
            Width  = width;
            Height = height;
        }
    }

    class VideoSettings
    {
        public VideoResolution Fs;
        public VideoResolution Win;

        public bool FullScreen;
        public VSyncMode Vsync;

        public VideoSettings()
        {
            Fs  = new VideoResolution();
            Win = new VideoResolution();

            FullScreen = true;
            Vsync = VSyncMode.On;
        }
    }
}
