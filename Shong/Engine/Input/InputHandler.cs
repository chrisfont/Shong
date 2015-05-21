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

                // Set Input Delegates
                _win.KeyDown += KeyDown;
                _win.KeyUp   += KeyUp;
            }
            else
            {
                Log.Instance.LogMsg(LogType.Error,
                                    "Bad window or settings passed for input init.");
            }
        }

        public void Handle()
        {
            // Handle all events in queue
            // TODO: Add timeout for this!!
            while(!InputEventQueue.Instance.queue.Count.Equals(0))
            {
                var ev = InputEventQueue.Instance.Dequeue();

                if(ev.Keyboard != null) HandleKeyEvent(ev.Keyboard);
                if(ev.Mouse != null)    HandleMouseEvent(ev.Mouse);
            }
        }

        private void HandleMouseEvent(InputMouse mouse)
        {
        }

        private void HandleKeyEvent(InputKeyboard keyboard)
        {
        }

        public void KeyUp(object sender, EventArgs e)
        {
            KeyAdd(e.Key, KeyAction.Release);
        }

        public void KeyDown(object sender, EventArgs e)
        {
            KeyAdd(e.Key, KeyAction.Press);
        }

        public void KeyAdd(Key key, KeyAction action)
        {
            var newEv = new InputEvent(new InputKeyboard(key, action));
            InputEventQueue.Instance.Enqueue(newEv);
        }
    }
}
