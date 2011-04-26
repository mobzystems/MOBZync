using System;
using System.Collections.Generic;
using System.Text;

namespace MOBZystems
{
  /// <summary>
  /// A file item. Represents a file system file with associated icons.
  /// </summary>
  public class FileItem: FileSystemItem
  {
    #region Constructors
    public FileItem(FolderItem parentFolder, string name, long size, DateTime modifiedDateTime) :
      base(parentFolder, name, size, modifiedDateTime)
    {
    }
    #endregion

    #region Methods
    /// <summary>
    /// Set the compare state of ourselves and another FileItem based
    /// on the result of a comparison
    /// </summary>
    /// <param name="otherFile"></param>
    public void CompareTo(FileItem otherFile)
    {
      if (this.modifiedDateTime == otherFile.modifiedDateTime)
      {
        this.State = CompareState.Unchanged;
        otherFile.State = CompareState.Unchanged;
      }
      else if (this.modifiedDateTime < otherFile.modifiedDateTime)
      {
        this.State = CompareState.Older;
        otherFile.State = CompareState.Newer;
      }
      else
      {
        this.State = CompareState.Newer;
        otherFile.State = CompareState.Older;
      }
    }
    #endregion

  }
}
