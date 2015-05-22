using System;
using System.Collections.Generic;
using OpenTK;

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

        public List<VideoResolution> AvailableRes { get; private set; }

        public bool FullScreen;
        public VSyncMode Vsync;

        public VideoSettings()
        {
            Fs  = new VideoResolution();
            Win = new VideoResolution();

            AvailableRes = new List<VideoResolution>();

            FullScreen = true;
            Vsync = VSyncMode.On;
        }

        public void GetResolutions(DisplayDevice device)
        {
            // Cycle through the available resolutions and store them in AvailableRes
            foreach (var res in device.AvailableResolutions)
            {
                AvailableRes.Add(new VideoResolution(res.Width, res.Height));
            }
        }
    }
}
