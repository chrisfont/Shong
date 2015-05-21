namespace Shong.Engine
{
    class EventQueue
    {
        // For Singleton
        private static          EventQueue _instance = null;
        private static readonly object     PadLock = new object();

        public Queue<Events> queue = null;

        EventQueue()
        {
        }

        public static EventQueue Instance {
            get
            {
                lock(PadLock)
                {
                    return _instance ?? (_instance = new EventQueue());
                }
            }
        }
    }

    // What type of system events will there be??????
    class Events
    {
    }
}
