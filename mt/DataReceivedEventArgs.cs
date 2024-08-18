namespace MagTek
{
    using System;

    public class DataReceivedEventArgs : EventArgs
    {
        public DataReceivedEventArgs()
        {
        }

        public DataReceivedEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}