using OpenTK.Input;

namespace Shong.Engine.Input
{
    enum MouseAction{
        Move,
        Press,
        Release
    }

    enum KeyAction {
        Press,
        Release
    }

    class InputEventQueue
    {
        // For Singleton
        private static          InputEventQueue _instance = null;
        private static readonly object     PadLock = new object();

        private Queue<InputEvent> _queue = null;

        EventQueue()
        {
            _queue = new Queue<InputEvent>();
        }

        public static InputEventQueue Instance {
            get
            {
                lock(PadLock)
                {
                    return _instance ?? (_instance = new EventQueue());
                }
            }
        }

        public InputEvent Dequeue()
        {
            _queue.Dequeue();
        }

        public void Enqueue(InputEvent ev)
        {
            _queue.Enqueue(ev);
        }
    }

    class InputMouse
    {
        public Vector2     Pos;
        public int         Btn;
        public MouseAction Action;
    }

    class InputKeyboard
    {
        public Key       Key;
        public KeyAction Action;

        public InputKeyboard(Key key, KeyAction action)
        {
            Key    = key;
            Action = action;
        }
    }

    class InputEvent
    {
        public InputMouse    Mouse    = null;
        public InputKeyboard Keyboard = null;

        public InputEvent(InputMouse mouseInput)
        {
            Mouse = mouseInput;
        }

        public InputEvent(InputKeyboard keyboardInput)
        {
            Keyboard = keyboardInput;
        }
    }
}