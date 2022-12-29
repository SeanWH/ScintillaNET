using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScintillaNET.EventArgs
{
    // For internal use only
    internal sealed class SCNotificationEventArgs : System.EventArgs
    {
        public NativeMethods.SCNotification SCNotification { get; private set; }

        public SCNotificationEventArgs(NativeMethods.SCNotification scn)
        {
            SCNotification = scn;
        }
    }
}
