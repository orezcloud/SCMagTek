namespace MagTek
{
    using System;

    public class CheckScannedEventArgs : EventArgs
    {
        public CheckScannedEventArgs()
        {
        }

        public CheckScannedEventArgs(ScannedCheck check)
        {
            Check = check;
        }

        public ScannedCheck Check { get; set; }
    }
}