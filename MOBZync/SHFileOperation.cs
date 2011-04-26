using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace MOBZystems
{
  public class ShellFileOperation
  {
    public enum FO_Func : uint
    {
      FO_MOVE = 0x0001,
      FO_COPY = 0x0002,
      FO_DELETE = 0x0003,
      FO_RENAME = 0x0004,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    struct SHFILEOPSTRUCT
    {
      public IntPtr hwnd;
      public FO_Func wFunc;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string pFrom;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string pTo;
      public ushort fFlags;
      public bool fAnyOperationsAborted;
      public IntPtr hNameMappings;
      [MarshalAs(UnmanagedType.LPWStr)]
      public string lpszProgressTitle;
    }

    [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
    static extern int SHFileOperation([In] ref SHFILEOPSTRUCT lpFileOp);

    private SHFILEOPSTRUCT _ShFile;
    public FILEOP_FLAGS fFlags;

    public IntPtr hwnd
    {
      set
      {
        this._ShFile.hwnd = value;
      }
    }

    public FO_Func wFunc
    {
      set
      {
        this._ShFile.wFunc = value;
      }
    }

    public string pFrom
    {
      set
      {
        this._ShFile.pFrom = value + '\0' + '\0';
      }
    }

    public string pTo
    {
      set
      {
        this._ShFile.pTo = value + '\0' + '\0';
      }
    }

    public bool fAnyOperationsAborted
    {
      get { return this._ShFile.fAnyOperationsAborted; }
      set { this._ShFile.fAnyOperationsAborted = value; }
    }

    public IntPtr hNameMappings
    {
      set
      {
        this._ShFile.hNameMappings = value;
      }
    }

    public string lpszProgressTitle
    {
      set
      {
        this._ShFile.lpszProgressTitle = value + '\0';
      }
    }

    public ShellFileOperation()
    {

      this.fFlags = new FILEOP_FLAGS();
      this._ShFile = new SHFILEOPSTRUCT();
      this._ShFile.hwnd = IntPtr.Zero;
      this._ShFile.wFunc = FO_Func.FO_COPY;
      this._ShFile.pFrom = "";
      this._ShFile.pTo = "";
      this._ShFile.fAnyOperationsAborted = false;
      this._ShFile.hNameMappings = IntPtr.Zero;
      this._ShFile.lpszProgressTitle = "";

    }

    public bool Execute()
    {
      this._ShFile.fFlags = this.fFlags.Flag;
      int ReturnValue = SHFileOperation(ref this._ShFile);
      if (ReturnValue == 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public class FILEOP_FLAGS
    {
      [Flags]
      private enum FILEOP_FLAGS_ENUM : ushort
      {
        FOF_MULTIDESTFILES = 0x0001,
        FOF_CONFIRMMOUSE = 0x0002,
        FOF_SILENT = 0x0004,                  // Don't create progress/report
        FOF_RENAMEONCOLLISION = 0x0008,
        FOF_NOCONFIRMATION = 0x0010,          // Don't prompt the user.
        FOF_WANTMAPPINGHANDLE = 0x0020,       // Fill in SHFILEOPSTRUCT.hNameMappings
                                              // Must be freed using SHFreeNameMappings
        FOF_ALLOWUNDO = 0x0040,
        FOF_FILESONLY = 0x0080,               // on *.*, do only files
        FOF_SIMPLEPROGRESS = 0x0100,          // means don't show names of files
        FOF_NOCONFIRMMKDIR = 0x0200,          // don't confirm making any needed dirs
        FOF_NOERRORUI = 0x0400,               // don't put up error UI
        FOF_NOCOPYSECURITYATTRIBS = 0x0800,   // don't copy NT file Security Attributes
        FOF_NORECURSION = 0x1000,             // don't recurse into directories.
        FOF_NO_CONNECTED_ELEMENTS = 0x2000,   // don't operate on connected elements.
        FOF_WANTNUKEWARNING = 0x4000,         // during delete operation, warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
        FOF_NORECURSEREPARSE = 0x8000,        // treat reparse points as objects, not containers
      }

      public bool FOF_MULTIDESTFILES = false;
      public bool FOF_CONFIRMMOUSE = false;
      public bool FOF_SILENT = false;
      public bool FOF_RENAMEONCOLLISION = false;
      public bool FOF_NOCONFIRMATION = false;
      public bool FOF_WANTMAPPINGHANDLE = false;
      public bool FOF_ALLOWUNDO = false;
      public bool FOF_FILESONLY = false;
      public bool FOF_SIMPLEPROGRESS = false;
      public bool FOF_NOCONFIRMMKDIR = false;
      public bool FOF_NOERRORUI = false;
      public bool FOF_NOCOPYSECURITYATTRIBS = false;
      public bool FOF_NORECURSION = false;
      public bool FOF_NO_CONNECTED_ELEMENTS = false;
      public bool FOF_WANTNUKEWARNING = false;
      public bool FOF_NORECURSEREPARSE = false;

      public ushort Flag
      {
        get
        {
          ushort ReturnValue = 0;

          if (this.FOF_MULTIDESTFILES == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_MULTIDESTFILES;
          if (this.FOF_CONFIRMMOUSE == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_CONFIRMMOUSE;
          if (this.FOF_SILENT == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_SILENT;
          if (this.FOF_RENAMEONCOLLISION == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_RENAMEONCOLLISION;
          if (this.FOF_NOCONFIRMATION == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_NOCONFIRMATION;
          if (this.FOF_WANTMAPPINGHANDLE == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_WANTMAPPINGHANDLE;
          if (this.FOF_ALLOWUNDO == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_ALLOWUNDO;
          if (this.FOF_FILESONLY == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_FILESONLY;
          if (this.FOF_SIMPLEPROGRESS == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_SIMPLEPROGRESS;
          if (this.FOF_NOCONFIRMMKDIR == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_NOCONFIRMMKDIR;
          if (this.FOF_NOERRORUI == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_NOERRORUI;
          if (this.FOF_NOCOPYSECURITYATTRIBS == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_NOCOPYSECURITYATTRIBS;
          if (this.FOF_NORECURSION == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_NORECURSION;
          if (this.FOF_NO_CONNECTED_ELEMENTS == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_NO_CONNECTED_ELEMENTS;
          if (this.FOF_WANTNUKEWARNING == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_WANTNUKEWARNING;
          if (this.FOF_NORECURSEREPARSE == true)
            ReturnValue |= (ushort)FILEOP_FLAGS_ENUM.FOF_NORECURSEREPARSE;

          return ReturnValue;
        }
      }
    }
  }
  
  public class FileOperation
  {
    /// <summary>
    /// Create a '\0'-delimited list of file names for a file operation.
    /// The list is terminated with a final '\0'
    /// </summary>
    /// <param name="names"></param>
    /// <returns></returns>
    private static string MakeFileNameList(string[] names)
    {
      StringBuilder sb = new StringBuilder();
      foreach (string s in names)
      {
        sb.Append(s);
        sb.Append('\0');
      }
      sb.Append('\0');
      return sb.ToString();
    }

    /// <summary>
    /// Copy a list of files.
    /// </summary>
    /// <param name="hwnd">The parent window for progress display etc.</param>
    /// <param name="fromNames">An array of source file names</param>
    /// <param name="toNames">An array of destination file names</param>
    /// <param name="title">The title to display</param>
    /// <returns>true on success, false on error</returns>
    public static bool CopyFiles(IntPtr hwnd, string[] fromNames, string[] toNames, string title, out bool AnyOperationsAborted)
    {
      if (fromNames == null)
        throw new ArgumentNullException("fromNames");
      if (toNames == null)
        throw new ArgumentNullException("toNames");
      if (fromNames.Length != toNames.Length)
        throw new ApplicationException("Source and destination file name arrays must have same length");
       
      ShellFileOperation sfo = new ShellFileOperation();
      sfo.wFunc = ShellFileOperation.FO_Func.FO_COPY;
      sfo.hwnd = hwnd;
      sfo.lpszProgressTitle = title;
      sfo.fFlags.FOF_MULTIDESTFILES = true;
      sfo.pFrom = MakeFileNameList(fromNames);
      sfo.pTo = MakeFileNameList(toNames);

      bool returnValue = sfo.Execute();

      AnyOperationsAborted = sfo.fAnyOperationsAborted;

      return returnValue;
    }

    /// <summary>
    /// Delete a list of files.
    /// </summary>
    /// <param name="hwnd">The parent window for progress display etc.</param>
    /// <param name="names">An array of source file names</param>
    /// <param name="title">The title to display</param>
    /// <returns>true on success, false on error</returns>
    public static bool DeleteFiles(IntPtr hwnd, string[] names, string title, out bool AnyOperationsAborted)
    {
      if (names == null)
        throw new ArgumentNullException("fromNames");

      ShellFileOperation sfo = new ShellFileOperation();
      sfo.wFunc = ShellFileOperation.FO_Func.FO_DELETE;
      sfo.hwnd = hwnd;
      sfo.lpszProgressTitle = title;
      sfo.pFrom = MakeFileNameList(names);
      sfo.pTo = "";

      bool returnValue = sfo.Execute();

      AnyOperationsAborted = sfo.fAnyOperationsAborted;
      
      return returnValue;
    }
  }
}
