﻿using OpenTK;

namespace Shong.Engine
{
    class Game
    {
        private GameWindow _mainWindow;
        private Settings _settings;
        private bool _gameRun = true;

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

            // Main Loop
            while (_gameRun)
            {
                
            }

            // Clean Up
        }
    }
}
