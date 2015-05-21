using System.Collections.Generic;

namespace Shong.Engine.Input
{
    class InputHandler
    {
        private Dictionary<Tuple<Key, KeyAction>, delegate>  _keyCallbacks;

        public InputHandler()
        {
            _keyCallbacks = new Dictionary<Tuple<Key, KeyAction>, delegate>();
        }

        public void Register(Key key, KeyAction action, delegate del)
        {
            _keyCallbacks.Add(new Tuple<Key, KeyAction>(key, action), del);
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
            var func = _keyCallbacks.Item(new Tuple<Key, KeyAction>(keyboard.Key, keyboard.Action));
            if(func != null) func();
        }

        public void KeyUp(object sender, EventArgs e)
        {
            KeyAdd(e.Key, KeyAction.Release);
        }

        public void KeyDown(object sender, EventArgs e)
        {
            KeyAdd(e.Key, KeyAction.Press);
        }

        private void KeyAdd(Key key, KeyAction action)
        {
            var newEv = new InputEvent(new InputKeyboard(key, action));
            InputEventQueue.Instance.Enqueue(newEv);
        }
    }
}
