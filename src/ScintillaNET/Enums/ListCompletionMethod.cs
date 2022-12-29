using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using ScintillaNET.EventArgs;

namespace ScintillaNET.Enums
{
    /// <summary>
    /// Indicates how an autocompletion occurred.
    /// </summary>
    public enum ListCompletionMethod
    {
        /// <summary>
        /// A fillup character (see <see cref="Scintilla.AutoCSetFillUps" />) triggered the completion.
        /// The character used is indicated by the <see cref="AutoCSelectionEventArgs.Char" /> property.
        /// </summary>
        FillUp = NativeMethods.SC_AC_FILLUP,

        /// <summary>
        /// A double-click triggered the completion.
        /// </summary>
        DoubleClick = NativeMethods.SC_AC_DOUBLECLICK,

        /// <summary>

        /* Unmerged change from project 'ScintillaNET (net6.0-windows)'
        Before:
                /// A tab key or the <see cref="ScintillaNET.Command.Tab" /> command triggered the completion.
        After:
                /// A tab key or the <see cref="Command.Tab" /> command triggered the completion.
        */
        /// A tab key or the <see cref="VisualStyleElement.Tab" /> command triggered the completion.
        /// </summary>
        Tab = NativeMethods.SC_AC_TAB,

        /// <summary>

        /* Unmerged change from project 'ScintillaNET (net6.0-windows)'
        Before:
                /// A new line or <see cref="ScintillaNET.Command.NewLine" /> command triggered the completion.
        After:
                /// A new line or <see cref="Command.NewLine" /> command triggered the completion.
        */
        /// A new line or <see cref="Command.NewLine" /> command triggered the completion.
        /// </summary>
        NewLine = NativeMethods.SC_AC_NEWLINE,

        /// <summary>
        /// The <see cref="Scintilla.AutoCSelect" /> method triggered the completion.
        /// </summary>
        Command = NativeMethods.SC_AC_COMMAND
    }
}
