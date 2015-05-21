using OpenTK;

namespace Shong.Engine.Input
{
    class InputHandler
    {
        private GameWindow _win = null;
        private InputSettings _settings;

        public InputHandler(GameWindow win, InputSettings inputSettings)
        {
            if (win != null && inputSettings != null)
            {
                _win = win;
                _settings = inputSettings;
            }
            else
            {
                Log.Instance.LogMsg(LogType.Error, "Bad window or settings passed for input init.");
            }

            // Initialize Callbacks
        }
    }
}
