using System;
using System.Windows.Forms;

namespace MOBZystems
{
  public class WaitCursor: IDisposable
  {
    protected static int waitCounter = 0;
    protected static Cursor waitCursorType = Cursors.WaitCursor;
    protected static Cursor savedCursor;

    private bool disposed = false;

    /// <summary>
    /// Create a new WaitCursor that sets the cursor to the type configured in WaitCursor.WaitCursorType
    /// if this is the first WaitCursor in existence.
    /// </summary>
    public WaitCursor()
    {
      // Are we showing this cursor for the first time?
      if (waitCounter++ == 0)
      {
        // Save the cursor, set it to the configured wait cursor
        savedCursor = Cursor.Current;
        Cursor.Current = waitCursorType;
      }
    }

    /// <summary>
    /// Property WaitCursorType (Cursor). The cursor to use as the wait cursor
    /// </summary>
    /// <remarks></remarks>
    public static Cursor WaitCursorType
    {
      get
      {
        return waitCursorType;
      }
      set
      {
        waitCursorType = value;
      }
    }

    /// <summary>
    /// Reset the cursor to the specified cursor
    /// </summary>
    /// <param name="cursor">The new cursor</param>
    public static void Reset(Cursor cursor)
    {
      waitCounter = 0;
      Cursor.Current = cursor;
    }

    /// <summary>
    /// Reset the cursor to the default cursor
    /// </summary>
    public static void Reset()
    {
      Reset(Cursors.Default);
    }

    #region IDisposable Members
    public void Dispose()
    {
      if (!this.disposed)
      {
        this.disposed = true;

        // Decrement the wait cursor, restore if 0
        if (--waitCounter == 0)
          Cursor.Current = savedCursor;
      }
    }
    #endregion
  }
}
