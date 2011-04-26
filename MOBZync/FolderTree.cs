using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.IO;
using MOBZystems;

namespace MOBZync
{
  /// <summary>
  /// Displays and navigates the contents of a FolderItem using a combination of a tree view and a list view
  /// </summary>
  public partial class FolderTree : UserControl
  {
    /// <summary>
    /// Class StatusChangedEventArgs
    /// </summary>
    public class StatusChangedEventArgs : EventArgs
    {
      protected string status;

      /// <summary>
      /// Property Status (string)
      /// </summary>
      /// <remarks></remarks>
      public string Status
      {
        get
        {
          return this.status;
        }
        set
        {
          this.status = value;
        }
      }

      /// <summary>
      /// Default constructor
      /// </summary>
      public StatusChangedEventArgs(string status)
      {
        this.status = status;
      }
    }

    /// <summary>
    /// Delegate for StatusChanged event
    /// </summary>
    public delegate void StatusChangedEventHandler(object sender, StatusChangedEventArgs e);

    /// <summary>
    /// StatusChanged event
    /// </summary>
    public event StatusChangedEventHandler StatusChanged;

    // Raise the StatusChanged event
    protected virtual void OnStatusChanged(StatusChangedEventArgs e)
    {
      if (this.StatusChanged != null)
        this.StatusChanged(this, e);
    }

    #region Comparer
    /// <summary>
    /// Compares two file system items based on an index and an ascending flag
    /// </summary>
    /// <typeparam name="T">FolderItem or FileItem</typeparam>
    private class FileSystemItemComparer<T> : IComparer<T> where T : FileSystemItem
    {
      // The sort index and sort direction
      private int sortIndex;
      private bool sortAscending;

      /// <summary>
      /// Constructor. Set sort index and order
      /// </summary>
      /// <param name="sortIndex"></param>
      /// <param name="sortAscending"></param>
      public FileSystemItemComparer(int sortIndex, bool sortAscending)
      {
        this.sortIndex = sortIndex;
        this.sortAscending = sortAscending;
      }

      /// <summary>
      /// Implementation of IComparer for two FileSystemItems
      /// </summary>
      /// <param name="fsi1">FileSystemItem one</param>
      /// <param name="fsi2">FileSystemItem two</param>
      /// <returns>-1 if one &lt; two; +1 if two > one; else 0</returns>
      int IComparer<T>.Compare(T fsi1, T fsi2)
      {
        // The result
        int result;

        // Compare based on sort index:
        switch (this.sortIndex)
        {
          case 1: // Size
            result = fsi1.Size.CompareTo(fsi2.Size);
            break;
          case 2: // Modified-date
            result = fsi1.ModifiedDateTime.CompareTo(fsi2.ModifiedDateTime);
            break;
          case 3: // Compare state
            result = fsi1.State.CompareTo(fsi2.State);
            break;
          default: // Including case 0: Name
            result = 0; // Defer until later -- pretend 'equal'
            break;
        }

        // No decision yet?
        if (result == 0)
        {
          // Use the name:
          result = fsi1.Name.CompareTo(fsi2.Name);
        }

        // When not sorting ascending, invert the result
        if (!this.sortAscending)
          result = -result;

        // Return the result
        return result;
      }
    }
    #endregion

    #region Members
    // The root folder of this folder tree
    private FolderItem rootFolder;
    // The current display folder of this folder tree
    private FolderItem currentFolder;

    // An array of booleans that determines if a state is visible
    protected bool[] stateDisplay = new bool[(int)CompareState.Last];

    // The 'other' FolderTree control we keep ourselves in sync with
    private FolderTree buddyControl;

    // Internal variable for preventing re-entrancy in Resize()
    private int resizeCounter = 0;

    private bool isUpdatingList = false;
    private bool selectingFolder = false;

    // Sorting in the list view
    // Default sort on name
    private int sortIndex = 0;
    // And ascending
    private bool sortAscending = true;
    #endregion

    #region Events
    /// <summary>
    /// SelectedItemChanged event
    /// </summary>
    public event EventHandler SelectedItemChanged;

    // Raise the SelectedItemChanged event
    protected virtual void OnSelectedItemChanged(EventArgs e)
    {
      if (this.SelectedItemChanged != null)
        this.SelectedItemChanged(this, e);
    }

    /// <summary>
    /// CurrentFolderChanged event
    /// </summary>
    public event EventHandler CurrentFolderChanged;

    // Raise the CurrentFolderChanged event
    protected virtual void OnCurrentFolderChanged(EventArgs e)
    {
      if (this.CurrentFolderChanged != null)
        this.CurrentFolderChanged(this, e);
    }
    #endregion

    #region Constructors
    public FolderTree()
    {
      InitializeComponent();
    }
    #endregion

    #region Properties
    /// <summary>
    /// Property StateImageList (ImageList)
    /// </summary>
    public ImageList StateImageList
    {
      get
      {
        return this.listView.StateImageList;
      }
      set
      {
        this.listView.StateImageList = value;
        this.treeView.StateImageList = value;
      }
    }

    /// <summary>
    /// Property BuddyControl (FolderTree)
    /// </summary>
    public FolderTree BuddyControl
    {
      get
      {
        return this.buddyControl;
      }
      set
      {
        this.buddyControl = value;

        if (this.buddyControl != null)
          this.buddyControl.splitContainer.SplitterMoved += new SplitterEventHandler(buddyControl_SplitterMoved);
      }
    }

    /// <summary>
    /// Get the root folder of this FolderTree. Can be null!
    /// </summary>
    public FolderItem RootFolder
    {
      get
      {
        return this.rootFolder;
      }
    }

    /// <summary>
    /// Determine if the FolderTree is displaying a folder
    /// </summary>
    public bool HasFolder
    {
      get
      {
        return this.rootFolder != null;
      }
    }

    /// <summary>
    /// Get/Set the current folder of this FolderTree, i.e. the folder displayed in the list view
    /// </summary>
    public FolderItem CurrentFolder
    {
      get
      {
        return this.currentFolder;
      }
      set
      {
        this.currentFolder = value;
      }
    }

    /// <summary>
    /// Retrieve the root state of the folder. If not None, a compare was issued
    /// </summary>
    public CompareState RootState
    {
      get
      {
        if (this.rootFolder != null)
          return this.rootFolder.State;
        else
          return CompareState.None;
      }
    }

    /// <summary>
    /// Is this FolderTree ready to sync?
    /// </summary>
    public bool WasCompared
    {
      get
      {
        return this.RootState != CompareState.None;
      }
    }

    /// <summary>
    /// Retrieve the selected item in the list view. Can be a folder or a file
    /// </summary>
    public FileSystemItem SelectedItem
    {
      get
      {
        if (this.listView.SelectedItems.Count == 0)
          return null;
        FileSystemItem item = (FileSystemItem)this.listView.SelectedItems[0].Tag;
        return item;
      }
    }

    /// <summary>
    /// Retrieve the selected folder in the tree view
    /// </summary>
    public FolderItem SelectedFolder
    {
      get
      {
        if (this.treeView.SelectedNode == null)
          return null;

        FolderItem folder = (FolderItem)this.treeView.SelectedNode.Tag;
        return folder;
      }
    }

    /// <summary>
    /// Property IsUpdatingList (bool)
    /// </summary>
    /// <remarks></remarks>
    public bool IsUpdatingList
    {
      get
      {
        return this.isUpdatingList;
      }
    }

    #endregion

    #region Overridden methods
    /// <summary>
    /// Set image lists in OnLoad
    /// </summary>
    /// <param name="e"></param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      // Set the image list to the system image list:
      this.listView.SmallImageList = FileSystemItem.SmallImageList;
      this.listView.LargeImageList = FileSystemItem.LargeImageList;
      this.treeView.ImageList = FileSystemItem.SmallImageList;
    }

    /// <summary>
    /// Keep track of whether we're currently resizing
    /// </summary>
    /// <param name="e"></param>
    protected override void OnResize(EventArgs e)
    {
      this.resizeCounter++;
      base.OnResize(e);
      this.resizeCounter--;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Set the root path of this folder tree. Inializes all internal data and redisplays.
    /// </summary>
    /// <param name="rootPathIn"></param>
    public void SetRootPath(string rootPathIn)
    {
      using (new WaitCursor())
      {
        // Use the correct spelling for the root directory name:
        DirectoryInfo dirInfo = new DirectoryInfo(rootPathIn);
        string rootPath = dirInfo.FullName;

        // Store it in the text box if that is empty:
        if (this.folderTextBox.Text.Length == 0)
          this.folderTextBox.Text = rootPath;
        FolderItem newRootFolder = new FolderItem(null, rootPath, DateTime.Now);
        newRootFolder.Fill(rootPath, true);

        this.rootFolder = newRootFolder;
        this.currentFolder = this.RootFolder;

        RedisplayFolders();

        // MessageBox.Show("There are currently " + FileSystemItem.ImageList.Images.Count.ToString() + " images in the system image list");
      }
    }

    public void Clear()
    {
      this.rootFolder = null;
      this.currentFolder = null;

      Redisplay(true);
    }

    /// <summary>
    /// Set the display state of a compare state to true or false
    /// </summary>
    /// <param name="state">The compare state to change</param>
    /// <param name="show">Whether to show that compare state</param>
    public void SetStateDisplay(CompareState state, bool show)
    {
      this.stateDisplay[(int)state] = show;
    }

    /// <summary>
    /// Get the display state of a compare state
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    public bool GetStateDisplay(CompareState state)
    {
      return this.stateDisplay[(int)state];
    }

    /// <summary>
    /// Redisplay the list view
    /// </summary>
    public void Redisplay()
    {
      Redisplay(false);
    }

    /// <summary>
    /// Redisplay the list view (possibly with autosize)
    /// </summary>
    /// <param name="autoSize"></param>
    public void Redisplay(bool autoSize)
    {
      // Clear the list view items (but not the column headers!)
      this.listView.Items.Clear();

      if (this.rootFolder == null)
      {
        // TODO: display a single item to indicate the list is empty
        this.treeView.Nodes.Clear();
      }
      else if (this.currentFolder != null)
      {
        using (new WaitCursor())
        {
          OnStatusChanged(new FolderTree.StatusChangedEventArgs("Updating " + currentFolder.Name + "..."));

          this.statusLabel.Text = "Updating " + currentFolder.Name + "...";
          this.statusStrip.Refresh();

          this.listView.BeginUpdate();
          this.isUpdatingList = true;

          try
          {
            this.currentFolder.Folders.Sort(new FileSystemItemComparer<FolderItem>(this.sortIndex, this.sortAscending));

            // First, add all folders
            foreach (FolderItem folder in this.currentFolder.Folders)
            {
              if (folder.State == CompareState.None || this.GetStateDisplay(folder.State))
              {
                ListViewItem item = this.listView.Items.Add(Path.GetFileName(folder.Name), folder.SmallIconIndex);
                item.SubItems.Add(folder.Size.ToString("#,,0"));
                item.SubItems.Add(folder.ModifiedDateTime.ToString());
                item.SubItems.Add(folder.State.ToString());
                item.Tag = folder;
                item.StateImageIndex = (int)folder.State;
              }
            }

            this.currentFolder.Files.Sort(new FileSystemItemComparer<FileItem>(this.sortIndex, this.sortAscending));

            // Then, add all files
            foreach (FileItem file in this.currentFolder.Files)
            {
              if (file.State == CompareState.None || this.GetStateDisplay(file.State))
              {
                if (file.SmallIconIndex == -1)
                  file.RetrieveIcons();

                ListViewItem item = this.listView.Items.Add(file.Name, file.SmallIconIndex);
                item.SubItems.Add(file.Size.ToString("#,,0"));
                item.SubItems.Add(file.ModifiedDateTime.ToString());
                item.SubItems.Add(file.State.ToString());
                item.Tag = file;
                item.StateImageIndex = (int)file.State;
              }
            }

            if (autoSize)
            {
              foreach (ColumnHeader header in this.listView.Columns)
              //if (header != this.stateColumnHeader)
              {
                header.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                if (header != this.stateColumnHeader)
                {
                  int w = header.Width;
                  header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize); // This is large if this is the last header!
                  if (header.Width < w)
                    header.Width = w;
                }
              }
            }

            // Set the status text
            this.statusLabel.Text = this.currentFolder.Folders.Count.ToString("#,,0") + " folder(s), " + this.currentFolder.Files.Count.ToString("#,,0") + " file(s).";
            this.statusStrip.Refresh();
          }
          finally
          {
            listView.EndUpdate();
            this.isUpdatingList = false;
            OnStatusChanged(new FolderTree.StatusChangedEventArgs(null));
          }
        }
      }
    }

    /// <summary>
    /// Redisplay the folder tree
    /// </summary>
    public void RedisplayFolders()
    {
      this.treeView.Nodes.Clear();

      TreeNode rootNode = this.treeView.Nodes.Add(this.rootFolder.FullName(), this.rootFolder.Name, this.rootFolder.SmallIconIndex);
      rootNode.StateImageIndex = (int)this.rootFolder.State;
      rootNode.Tag = this.rootFolder;

      AddFoldersToNode(this.rootFolder, rootNode);

      // Expand the root node
      rootNode.Expand();
    }

    /// <summary>
    /// Helper function to recursively add folders to a node
    /// </summary>
    /// <param name="folder"></param>
    /// <param name="node"></param>
    private void AddFoldersToNode(FolderItem folder, TreeNode node)
    {
      foreach (FolderItem f in folder.Folders)
      {
        TreeNode childNode = node.Nodes.Add(f.Name, Path.GetFileName(f.Name), f.SmallIconIndex);
        childNode.StateImageIndex = (int)f.State;
        childNode.Tag = f;

        AddFoldersToNode(f, childNode);
      }
    }

    /// <summary>
    /// Add the specified path to the folder history
    /// </summary>
    /// <param name="path"></param>
    private void AddPathToHistory(string path)
    {
      if (!this.folderTextBox.Items.Contains(path))
        this.folderTextBox.Items.Add(path);
    }

    /// <summary>
    /// Set the new root path
    /// </summary>
    /// <param name="path"></param>
    private void SetNewFolderPath(string path)
    {
      this.SetRootPath(path);

      // Store the path in the folder text box
      this.folderTextBox.Text = path;
      // Add the path to the path history
      AddPathToHistory(path);
    }

    public bool SelectFolder(string relativePath)
    {
      // the input folder name is \one\two\three
      TreeNode n = FindNodeWithRelativeFolder(this.treeView.Nodes, relativePath);
      if (n == null)
      {
        this.treeView.SelectedNode = null;
        this.currentFolder = null;
        Redisplay(true);
      }
      else if (/* n != null && */ this.treeView.SelectedNode != n)
      {
        this.selectingFolder = true;
        this.treeView.SelectedNode = n;
        this.selectingFolder = false;
        return true;
      }

      return false;
    }

    public TreeNode FindNodeWithRelativeFolder(TreeNodeCollection nodes, string relativePath)
    {
      foreach (TreeNode node in nodes)
      {
        FolderItem folder = (FolderItem)node.Tag;
        if (folder.Name.Substring(this.rootFolder.Name.Length).ToLowerInvariant() == relativePath.ToLowerInvariant())
          return node;

        TreeNode n = FindNodeWithRelativeFolder(node.Nodes, relativePath);
        if (n != null)
          return n;
      }

      return null;
    }

    /// <summary>
    /// Select an item in the list view
    /// </summary>
    /// <param name="name"></param>
    public void SelectItemWithName(string name)
    {
      ListViewItem item = this.listView.FindItemWithText(name);
      if (item == null)
      {
        this.listView.SelectedItems.Clear();
      }
      else if (this.listView.SelectedItems.Count != 1 || this.listView.SelectedItems[0] != item)
      {
        this.listView.SelectedItems.Clear();
        item.Selected = true;
        item.EnsureVisible();
      }
    }
    #endregion

    #region ListView event handlers
    private void listView_SelectedIndexChanged(object sender, EventArgs e)
    {
      // if (this.SelectedItem is FileItem)
      OnSelectedItemChanged(EventArgs.Empty);
    }

    private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      int newSortIndex = e.Column;
      if (newSortIndex == this.sortIndex)
      {
        this.sortAscending = !this.sortAscending;
      }
      else
      {
        this.sortIndex = newSortIndex;
        this.sortAscending = true;
      }

      Redisplay();
    }

    private void listView_DoubleClick(object sender, EventArgs e)
    {
      // FileSystemItem item = this.SelectedItem;
      FolderItem folder = this.SelectedItem as FolderItem;
      if (folder != null)
      {
        // this.currentFolder = folder;
        // this.treeView.SelectedNode = null;
        SelectFolder(folder.Name.Substring(this.rootFolder.Name.Length));
        // Redisplay(true);
        // OnCurrentFolderChanged(EventArgs.Empty);
      }
      // TODO: file
    }
    #endregion

    #region TreeView event handlers
    private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      // if (!this.selectingFolder)
      {
        FolderItem folderItem = e.Node.Tag as FolderItem;
        if (folderItem != null && this.currentFolder != folderItem)
        {
          this.currentFolder = folderItem;
          OnCurrentFolderChanged(EventArgs.Empty);
          Redisplay(true);
        }
      }
    }
    #endregion

    #region Buddy control event handlers
    private void buddyControl_SplitterMoved(object sender, SplitterEventArgs e)
    {
      // Make sure this does NOT happen when both splitters move simultaneously because of a resize!
      if (this.resizeCounter == 0)
      {
        // Set our own splitter value
        this.splitContainer.SplitterDistance = this.buddyControl.splitContainer.SplitterDistance;
      }
    }
    #endregion

    #region FolderTextBox event handlers
    private void folderTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\r')
      {
        e.Handled = true;
        try
        {
          SetNewFolderPath(this.folderTextBox.Text);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Error reading folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        Redisplay(true);
      }
    }

    private void folderTextBox_DropDownClosed(object sender, EventArgs e)
    {
      if (this.folderTextBox.SelectedIndex >= 0)
      {
        // The text has not been transferred to the text property yet...
        string path = (string)this.folderTextBox.Items[this.folderTextBox.SelectedIndex];

        try
        {
          SetNewFolderPath(path);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Error reading folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Always redisplay!
        Redisplay(true);
      }
    }
    #endregion

    #region Toolbar button event handlers
    private void browseButton_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog fbd = new FolderBrowserDialog();

      fbd.ShowNewFolderButton = false;
      fbd.Description = "Open a folder to compare";

      if (this.rootFolder != null)
        fbd.SelectedPath = this.rootFolder.FullName();
      else if (this.folderTextBox.Text.Length != 0)
        fbd.SelectedPath = this.folderTextBox.Text;

      if (fbd.ShowDialog(this) == DialogResult.OK)
      {
        string path = fbd.SelectedPath;

        try
        {
          SetNewFolderPath(path);
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Error reading folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Always redisplay!
        Redisplay(true);
      }
    }

    private void folderUpButton_Click(object sender, EventArgs e)
    {
      if (this.currentFolder != null && this.currentFolder.ParentFolder != null)
      {
        this.currentFolder = this.currentFolder.ParentFolder;
        // OnCurrentFolderChanged(EventArgs.Empty);
        Redisplay();
      }
    }
    #endregion

    private void toolStrip_SizeChanged(object sender, EventArgs e)
    {
      this.folderTextBox.Width = this.ClientSize.Width - this.folderUpButton.Width - this.browseButton.Width - this.Padding.Left - this.Padding.Right - this.Margin.Left - this.Margin.Right;
    }
  }
}
