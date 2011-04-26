using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace MOBZystems
{
  /// <summary>
  /// Compare state
  /// </summary>
  public enum CompareState
  {
    First = 0,

    None = -1,

    Unchanged = First,
    Older = 1,
    Newer = 2,
    Added = 3,

    Last = Added + 1
  };

  /// <summary>
  /// The base class for items displayable in a FolderTree, e.g. FileItem and FolderItem.
  /// </summary>
  public class FileSystemItem
  {
    #region Members
    // The name of the item
    protected string name;
    // The size of the file in bytes
    protected long size;
    // The modified date/time of the file
    protected DateTime modifiedDateTime;
    // The parent folder of this object
    protected FolderItem parentFolder;
    // The compare state of the file system item (older, newer, etc.)
    protected CompareState state;
    // The icon index in the system image list of the *small* icon
    protected int smallIconIndex = -1;
    // The icon index in the system image list of the *large* icon
    protected int largeIconIndex = -1;

    // A singular system image list for all file system items, small and large version
    static protected SystemImageList smallIcons = new SystemImageList(SystemInformation.SmallIconSize);
    static protected SystemImageList largeIcons = new SystemImageList(SystemInformation.IconSize);
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor with parent folder, name, size and modified date
    /// </summary>
    /// <param name="parentFolder">The parent folder this item is in</param>
    /// <param name="name">The name of this item</param>
    /// <param name="size">The size of this item</param>
    /// <param name="modifiedDateTime">The modified date/time of this item</param>
    public FileSystemItem(FolderItem parentFolder, string name, long size, DateTime modifiedDateTime)
    {
      this.parentFolder = parentFolder;
      this.name = name;
      this.size = size;
      this.modifiedDateTime = modifiedDateTime;

      // Default sync state is NONE
      this.state = CompareState.None;

      // Icons are not initialized here, because that is slow
    }
    #endregion

    #region Properties
    /// <summary>
    /// Property Size (long)
    /// </summary>
    public long Size
    {
      get
      {
        return this.size;
      }
      set
      {
        this.size = value;
      }
    }

    /// <summary>
    /// Property ModifiedDateTime (DateTime)
    /// </summary>
    public DateTime ModifiedDateTime
    {
      get
      {
        return this.modifiedDateTime;
      }
      set
      {
        this.modifiedDateTime = value;
      }
    }

    /// <summary>
    /// Property Name (string)
    /// </summary>
    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    /// <summary>
    /// Property ParentFolder (FolderItem)
    /// </summary>
    public FolderItem ParentFolder
    {
      get
      {
        return this.parentFolder;
      }
    }

    /// <summary>
    /// Property State (CompareState)
    /// </summary>
    public CompareState State
    {
      get
      {
        return this.state;
      }
      set
      {
        this.state = value;
      }
    }

    /// <summary>
    /// Get the small icon index of this file. Is -1 if not retrieved using RetrieveIcon()
    /// </summary>
    public int SmallIconIndex
    {
      get
      {
        return this.smallIconIndex;
      }
    }

    /// <summary>
    /// Property LargeIconIndex (int)
    /// </summary>
    public int LargeIconIndex
    {
      get
      {
        return this.largeIconIndex;
      }
    }
    #endregion

    #region Static properties
    /// <summary>
    /// Property SmallImageList (ImageList)
    /// </summary>
    public static ImageList SmallImageList
    {
      get
      {
        return smallIcons.ImageList;
      }
    }

    /// <summary>
    /// Property LargeImageList (ImageList)
    /// </summary>
    public static ImageList LargeImageList
    {
      get
      {
        return largeIcons.ImageList;
      }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Return the full name of the object.
    /// </summary>
    /// <returns>The name of all parents plus our own name, separated by a backslash</returns>
    public string FullName()
    {
      string n = this.name;
      FolderItem p = this.ParentFolder;
      while (p != null)
      {
        n = Path.Combine(p.name, n);
        p = p.ParentFolder;
      }

      return n;
    }

    /// <summary>
    /// Retrieve the file icon indices for this item.
    /// If the icons have already been retrieved, skip them
    /// </summary>
    public void RetrieveIcons()
    {
      RetrieveIcons(false);
    }

    /// <summary>
    /// Retrieve icons with possible forced refresh. Must be called explicitly because it may be slow!
    /// </summary>
    /// <param name="forceRefresh">If true, refresh icons; if false, ony retrive if not done already</param>
    public void RetrieveIcons(bool forceRefresh)
    {
      if (forceRefresh || (this.smallIconIndex == -1 && this.largeIconIndex == -1))
      {
        string fullName = FullName();
        if (fullName != null && fullName.Length != 0)
        {
          this.smallIconIndex = smallIcons.AddIconForFile(fullName, false);
          this.largeIconIndex = largeIcons.AddIconForFile(fullName, true);
        }
      }
    }
    #endregion
  }
}
