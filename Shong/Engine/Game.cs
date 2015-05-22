using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Shong.Engine.Input;

namespace Shong.Engine
{
    class Game
    {
        // Version
        private const int MajVer = 0;
        private const int MinVer = 1;
        private const int PatchVer = 0;

        public static readonly string VersionStr = String.Format("v{0}.{1}.{2}", MajVer, MinVer, PatchVer);
        public static readonly string Title = "Shong " + VersionStr;

        private GameWindow   _mainWindow;
        private Settings     _settings;
        private InputHandler _input;

        public Game()
        {
        }

        public void Run()
        {
            // Initialize Logging System
            Log.Instance.FilePath = "../../shong.log";

            // Initialize Settings
            _settings = new Settings("../../cfg.json");

            // Initialize Graphics

            // Initialize Input
            _input = new InputHandler();

            // Register system commands
            _input.Register(Key.Escape, KeyAction.Press, Quit);
            
            _mainWindow = new GameWindow(
                width: _settings.Video.Win.Height, 
                height: _settings.Video.Win.Width, 
                mode: new GraphicsMode(), 
                title: Title);

            _mainWindow.KeyDown += _input.KeyDown;
            _mainWindow.KeyUp   += _input.KeyUp;

            _mainWindow.UpdateFrame += (sender, e) =>
            {
                _input.Handle();
            };

            _mainWindow.RenderFrame += (sender, e) =>
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
                
                GL.Begin(PrimitiveType.Triangles);
                
                    GL.Color3(Color.Magenta);
                    GL.Vertex2(-1.0f, 1.0f);
                    GL.Color3(Color.Blue);
                    GL.Vertex2(0.0f, -1.0f);
                    GL.Color3(Color.DarkOrange);
                    GL.Vertex2(1.0f, 1.0f);

                GL.End();

                _mainWindow.SwapBuffers();
            };

            _mainWindow.Run(60.0);
        }

        void Quit()
        {
            _mainWindow.Exit();
        }
    }
}
