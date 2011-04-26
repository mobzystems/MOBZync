using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace MOBZystems
{
  /// <summary>
  /// ShFileInfo. Supports static methods for retrieving the icon
  /// and icon index for a file
  /// </summary>
  class SHFileInfo
  {
    #region SHFILEINFO
    [StructLayout(LayoutKind.Sequential)]
    private struct SHFILEINFO
    {
      // Handle to icon
      public IntPtr hIcon;
      // Index of icon in system image list
      public int iIcon;    
      public uint dwAttributes;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
      public string szDisplayName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
      public string szTypeName;
    };
    #endregion

    #region Members
    // Get icon *handle* into hIcon
    private const uint SHGFI_ICON = 0x100;
    // Get icon *index* into iIcon
    private const uint SHGFI_SYSICONINDEX = 0x4000;

    // 'Large icon
    private const uint SHGFI_LARGEICON = 0x0;
    // 'Small icon
    private const uint SHGFI_SMALLICON = 0x1;
    #endregion

    // The actual method that does all the hard work
    [DllImport("shell32.dll")]
    private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

    #region Methods
    /// <summary>
    /// Retrieve the file icon for a file
    /// </summary>
    /// <param name="filename">The name of the file</param>
    /// <param name="getLargeIcon">If true, gets the large icon; else the small icon</param>
    /// <returns>A System.Drawing.Icon</returns>
    public static System.Drawing.Icon GetFileIcon(string filename, bool getLargeIcon)
    {
      // Get the handle of the icon. Is IntPtr.Zero on error
      IntPtr hIcon = GetFileIconHandle(filename, getLargeIcon);

      if (hIcon == IntPtr.Zero)
        return null;

      // The icon handle is returned in the hIcon member of the shinfo struct
      // Create and return an icon from the handle
      return System.Drawing.Icon.FromHandle(hIcon);
    }

    /// <summary>
    /// Retrieve the icon handle for a file
    /// </summary>
    /// <param name="filename">The name of the file</param>
    /// <param name="getLargeIcon">If true, gets the handle of the large icon; else the handle of the small icon</param>
    /// <returns>A Windows HICON handle</returns>
    public static IntPtr GetFileIconHandle(string filename, bool getLargeIcon)
    {
      // Set up a SHFILEINFO structure
      SHFILEINFO shinfo = new SHFILEINFO();

      // Fill it with file information for the specified file
      if (SHGetFileInfo(
        filename,
        0,
        ref shinfo,
        (uint)Marshal.SizeOf(shinfo),
        SHGFI_ICON | (getLargeIcon ? SHGFI_LARGEICON : SHGFI_SMALLICON)
      ) != IntPtr.Zero)
      {
        return shinfo.hIcon;
      }
      else
        return IntPtr.Zero;
    }

    /// <summary>
    /// Get the icon index for a file. This is an index into the system image list.
    /// </summary>
    /// <param name="filename">The name of the file</param>
    /// <param name="getLargeIcon">If true, gets the index of the large icon; else the index of the small icon</param>
    /// <returns>The index of the specified file (0+). Return -1 in case of error.</returns>
    public static int GetFileIconIndex(string filename, bool getLargeIcon)
    {
      // Set up a SHFILEINFO structure
      SHFILEINFO shinfo = new SHFILEINFO();

      // Fill it with file information for the specified file
      if (SHGetFileInfo(
        filename,
        0,
        ref shinfo,
        (uint)Marshal.SizeOf(shinfo),
        SHGFI_SYSICONINDEX | (getLargeIcon ? SHGFI_LARGEICON : SHGFI_SMALLICON)
      ) != IntPtr.Zero)
      {
        return shinfo.iIcon;
      }
      else
        return -1;
    }
    #endregion

  }
}
