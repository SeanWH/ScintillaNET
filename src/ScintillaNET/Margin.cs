﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ScintillaNET.Collections;
using ScintillaNET.Enums;

namespace ScintillaNET
{
    /// <summary>
    /// Represents a margin displayed on the left edge of a <see cref="Scintilla" /> control.
    /// </summary>
    public class Margin
    {
        #region Fields

        private readonly Scintilla scintilla;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the background color of the margin when the <see cref="Type" /> property is set to <see cref="MarginType.Color" />.
        /// </summary>
        /// <returns>A Color object representing the margin background color. The default is Black.</returns>
        /// <remarks>Alpha color values are ignored.</remarks>
        public Color BackColor
        {
            get
            {
                var color = scintilla.DirectMessage(NativeMethods.SCI_GETMARGINBACKN, new IntPtr(Index)).ToInt32();
                return ColorTranslator.FromWin32(color);
            }
            set
            {
                if (value.IsEmpty)
                    value = Color.Black;

                var color = ColorTranslator.ToWin32(value);
                scintilla.DirectMessage(NativeMethods.SCI_SETMARGINBACKN, new IntPtr(Index), new IntPtr(color));
            }
        }

        /// <summary>
        /// Gets or sets the mouse cursor style when over the margin.
        /// </summary>
        /// <returns>One of the <see cref="MarginCursor" /> enumeration values. The default is <see cref="MarginCursor.Arrow" />.</returns>
        public MarginCursor Cursor
        {
            get
            {
                return (MarginCursor)scintilla.DirectMessage(NativeMethods.SCI_GETMARGINCURSORN, new IntPtr(Index));
            }
            set
            {
                var cursor = (int)value;
                scintilla.DirectMessage(NativeMethods.SCI_SETMARGINCURSORN, new IntPtr(Index), new IntPtr(cursor));
            }
        }

        /// <summary>
        /// Gets the zero-based margin index this object represents.
        /// </summary>
        /// <returns>The margin index within the <see cref="MarginCollection" />.</returns>
        public int Index { get; private set; }

        /// <summary>
        /// Gets or sets whether the margin is sensitive to mouse clicks.
        /// </summary>
        /// <returns>true if the margin is sensitive to mouse clicks; otherwise, false. The default is false.</returns>
        /// <seealso cref="Scintilla.MarginClick" />
        public bool Sensitive
        {
            get
            {
                return (scintilla.DirectMessage(NativeMethods.SCI_GETMARGINSENSITIVEN, new IntPtr(Index)) != IntPtr.Zero);
            }
            set
            {
                var sensitive = (value ? new IntPtr(1) : IntPtr.Zero);
                scintilla.DirectMessage(NativeMethods.SCI_SETMARGINSENSITIVEN, new IntPtr(Index), sensitive);
            }
        }

        /// <summary>
        /// Gets or sets the margin type.
        /// </summary>
        /// <returns>One of the <see cref="MarginType" /> enumeration values. The default is <see cref="MarginType.Symbol" />.</returns>
        public MarginType Type
        {
            get
            {
                return (MarginType)(scintilla.DirectMessage(NativeMethods.SCI_GETMARGINTYPEN, new IntPtr(Index)));
            }
            set
            {
                var type = (int)value;
                scintilla.DirectMessage(NativeMethods.SCI_SETMARGINTYPEN, new IntPtr(Index), new IntPtr(type));
            }
        }

        /// <summary>
        /// Gets or sets the width in pixels of the margin.
        /// </summary>
        /// <returns>The width of the margin measured in pixels.</returns>
        /// <remarks>Scintilla assigns various default widths.</remarks>
        public int Width
        {
            get
            {
                return scintilla.DirectMessage(NativeMethods.SCI_GETMARGINWIDTHN, new IntPtr(Index)).ToInt32();
            }
            set
            {
                value = Helpers.ClampMin(value, 0);
                scintilla.DirectMessage(NativeMethods.SCI_SETMARGINWIDTHN, new IntPtr(Index), new IntPtr(value));
            }
        }

        /// <summary>
        /// Gets or sets a mask indicating which markers this margin can display.
        /// </summary>
        /// <returns>
        /// An unsigned 32-bit value with each bit cooresponding to one of the 32 zero-based <see cref="Margin" /> indexes.
        /// The default is 0x1FFFFFF, which is every marker except folder markers (i.e. 0 through 24).
        /// </returns>
        /// <remarks>
        /// For example, the mask for marker index 10 is 1 shifted left 10 times (1 &lt;&lt; 10).
        /// <see cref="Marker.MaskFolders" /> is a useful constant for working with just folder margin indexes.
        /// </remarks>
        public uint Mask
        {
            get
            {
                return unchecked((uint)scintilla.DirectMessage(NativeMethods.SCI_GETMARGINMASKN, new IntPtr(Index)).ToInt32());
            }
            set
            {
                var mask = unchecked((int)value);
                scintilla.DirectMessage(NativeMethods.SCI_SETMARGINMASKN, new IntPtr(Index), new IntPtr(mask));
            }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Margin" /> class.
        /// </summary>
        /// <param name="scintilla">The <see cref="Scintilla" /> control that created this margin.</param>
        /// <param name="index">The index of this margin within the <see cref="MarginCollection" /> that created it.</param>
        public Margin(Scintilla scintilla, int index)
        {
            this.scintilla = scintilla;
            Index = index;
        }

        #endregion Constructors
    }
}
