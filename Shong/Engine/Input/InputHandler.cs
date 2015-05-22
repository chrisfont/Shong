using System;
using System.Collections.Generic;
using OpenTK.Input;

namespace Shong.Engine.Input
{
    class InputHandler
    {
        private readonly Dictionary<Tuple<Key, KeyAction>, Action> _keyCallbacks;

        public InputHandler()
        {
            _keyCallbacks = new Dictionary<Tuple<Key, KeyAction>, Action>();
        }

        public void Register(Key key, KeyAction action, Action func)
        {
            _keyCallbacks.Add(new Tuple<Key, KeyAction>(key, action), func);
        }

        public void Deregister(Key key, KeyAction action)
        {
            _keyCallbacks[new Tuple<Key, KeyAction>(key, action)] = null;
        }

        public void Handle()
        {
            // Handle all events in queue
            // TODO: Add timeout for this!!
            while(!InputEventQueue.Instance.Count.Equals(0))
            {
                var ev = InputEventQueue.Instance.Dequeue;

                if(ev.Keyboard != null) HandleKeyEvent(ev.Keyboard);
                if(ev.Mouse != null)    HandleMouseEvent(ev.Mouse);
            }
        }

        private void HandleMouseEvent(InputMouse mouse)
        {
        }

        private void HandleKeyEvent(InputKeyboard keyboard)
        {
            var func = _keyCallbacks[new Tuple<Key, KeyAction>(keyboard.Key, keyboard.Action)];
            if(func != null) func();
        }

        public void KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            KeyAdd(e.Key, KeyAction.Release);
        }

        public void KeyDown(object sender, KeyboardKeyEventArgs e)
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
