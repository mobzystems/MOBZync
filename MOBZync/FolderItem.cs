using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace MOBZystems
{
  /// <summary>
  /// Represents a folder in the file system. Can fill itself up with files and folders
  /// and compare itself to another folder.
  /// </summary>
  public class FolderItem : FileSystemItem
  {
    #region Members
    // The files in this folder
    protected List<FileItem> files;
    // The folders in this folder
    protected List<FolderItem> folders;
    #endregion

    #region Constructors
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="parentFolder">Parent folder</param>
    /// <param name="name">The name of the folder</param>
    /// <param name="modifiedDateTime">The modified date/time</param>
    public FolderItem(FolderItem parentFolder, string name, DateTime modifiedDateTime) :
      base(parentFolder, name, 0, modifiedDateTime)
    {
      // A folder retrieves its icons on startup, because folders are relatively rare
      this.RetrieveIcons();
    }

    /// <summary>
    /// Create a FolderItem and fill it with the contents of the supplied folder.
    /// </summary>
    /// <param name="folderName"></param>
    /// <param name="recursive"></param>
    public FolderItem(string folderName, bool recursive) :
      base(null, null, 0, DateTime.Now)
    {
      // Then fill ourselves with the supplied pattern:
      this.Fill(folderName, recursive);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Property Files
    /// </summary>
    public List<FileItem> Files
    {
      get
      {
        return this.files;
      }
    }

    /// <summary>
    /// Property Folders
    /// </summary>
    public List<FolderItem> Folders
    {
      get
      {
        return this.folders;
      }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Retrieve icons for all files
    /// </summary>
    public void RetrieveFileIcons()
    {
      foreach (FileItem file in this.files)
      {
        if (file.SmallIconIndex == -1 && file.LargeIconIndex == -1)
          file.RetrieveIcons();
      }
    }

    /// <summary>
    /// Fill the contents of this folder with information from the specified root path
    /// </summary>
    /// <param name="rootPath"></param>
    public void Fill(string rootPath, bool recursive)
    {
      DirectoryInfo rootDirInfo = new DirectoryInfo(rootPath);

      this.name = rootDirInfo.FullName;
      this.modifiedDateTime = rootDirInfo.LastWriteTimeUtc;
      this.size = 0;

      // First get all files
      this.files = new List<FileItem>();
      FileInfo[] rootFiles = rootDirInfo.GetFiles();
      foreach (FileInfo fileInfo in rootFiles)
      {
        FileItem fileItem = new FileItem(this, fileInfo.Name, fileInfo.Length, fileInfo.LastWriteTimeUtc);

        this.files.Add(fileItem);

        // Add the size of all files to our own size
        this.size += fileItem.Size;
      }

      // Then get the folders
      this.folders = new List<FolderItem>();
      DirectoryInfo[] rootFolders = rootDirInfo.GetDirectories();
      foreach (DirectoryInfo dirInfo in rootFolders)
      {
        FolderItem folderItem = new FolderItem(this, dirInfo.Name, dirInfo.LastWriteTimeUtc);

        this.folders.Add(folderItem);
      }

      if (recursive)
      {
        // Then fill up each directory:
        foreach (FolderItem subFolder in this.folders)
        {
          subFolder.Fill(Path.Combine(rootPath, subFolder.Name), recursive);

          // Count the size of the subdirectory in our own size:
          this.size += subFolder.Size;
        }
      }
    }

    /// <summary>
    /// Compare this folder to another one. Set all states of files and folders
    /// INCLUDING OUR OWN STATE
    /// </summary>
    /// <param name="otherFolder"></param>
    public void CompareTo(FolderItem otherFolder)
    {
      // Assume the lowest state for each
      CompareState myState = CompareState.Unchanged;
      CompareState otherState = CompareState.Unchanged;

      //if (this.files.Count == 0 && otherFolder.files.Count == 0)
      //{
      //  myState = CompareState.Equal;
      //  otherState = CompareState.Equal;
      //}
      //else
      //{
      // Iterate over our own files, comparing each
      foreach (FileItem file in this.files)
      {
        string name = file.Name;

        FileItem otherFile = otherFolder.FindFileByName(name);
        if (otherFile == null)
        {
          // Hey - no equivalent of our file found! Upgrade our own state to Added:
          myState = CompareState.Added;
        }
        else
        {
          file.CompareTo(otherFile);

          // If the file has a more important state than we do, update our state
          if (file.State > myState)
            myState = file.State;
        }
      }

      if (myState == CompareState.Added)
        otherState = CompareState.Older;
      else
      {
        // Update the other folder's state based on its files:
        foreach (FileItem file in otherFolder.files)
          if (file.State > otherState)
            otherState = file.State;
      }
      //}

      // Compare all folders
      foreach (FolderItem folder in this.folders)
      {
        string name = folder.Name;

        FolderItem folder2 = otherFolder.FindFolderByName(Path.GetFileName(name));
        if (folder2 != null)
        {
          // Compare the two folders:
          folder.CompareTo(folder2);

          // Upgrade our own state if we have to:
          if (folder.State > myState)
            myState = folder.State;
        }
      }

      if (myState == CompareState.Added)
        otherState = CompareState.Older;
      else
      {
        // Update the other folder's state based on its folders:
        foreach (FolderItem folder in otherFolder.folders)
          if (folder.State > otherState)
            otherState = folder.State;
      }

      // Now update our own and the other folder's states:
      this.State = myState;
      otherFolder.State = otherState;
    }

    /// <summary>
    /// Find and return a FileItem by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public FileItem FindFileByName(string name)
    {
      string nameLower = name.ToLower();

      foreach (FileItem item in this.files)
      {
        if (item.Name.ToLower() == nameLower)
          return item;
      }

      return null;
    }

    /// <summary>
    /// Find and return a FolderItem by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public FolderItem FindFolderByName(string name)
    {
      string nameLower = name.ToLower();

      foreach (FolderItem item in this.folders)
      {
        if (Path.GetFileName(item.Name).ToLowerInvariant() == nameLower)
          return item;
      }

      return null;
    }

    /// <summary>
    /// Find a folder or file by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public FileSystemItem FindItemByName(string name)
    {
      FileSystemItem item = this.FindFileByName(name);
      if (item != null)
        return item;
      item = this.FindFolderByName(name);
      return item;
    }

    /// <summary>
    /// Recursively sets all states to CompareState.Added
    /// </summary>
    public void SetAllItemsToAdded()
    {
      this.State = CompareState.Added;
      foreach (FileItem file in this.files)
        file.State = CompareState.Added;
      foreach (FolderItem folder in this.folders)
      {
        folder.SetAllItemsToAdded();
      }
    }
    #endregion
  }
}
