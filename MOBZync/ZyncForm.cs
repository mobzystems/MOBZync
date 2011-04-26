using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using MOBZystems;

namespace MOBZync
{
  /// <summary>
  /// Main form of this application. Displays two FolderTree controls, a menu, a tool strip, a status bar etc.
  /// </summary>
  public partial class ZyncForm : Form
  {
    #region Constructors
    public ZyncForm()
    {
      InitializeComponent();

      // Fix the state image list of the two folder trees.
      // State images cannot be transparent in PNG-form!
      ImageList newStateImageList = new ImageList();

      foreach (Image image in this.stateImageList.Images)
      {
        Bitmap bitmap = new Bitmap(this.stateImageList.ImageSize.Width, this.stateImageList.ImageSize.Height);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
          g.Clear(SystemColors.Window);
          g.DrawImage(image, 0, 0);
        }
        newStateImageList.Images.Add(bitmap);
      }

      this.folderTree1.StateImageList = newStateImageList;
      this.folderTree2.StateImageList = newStateImageList;

      this.showOlderButton.Image = this.stateImageList.Images["older"];
      this.showEqualButton.Image = this.stateImageList.Images["unchanged"];
      this.showNewerButton.Image = this.stateImageList.Images["newer"];
      this.showAddedButton.Image = this.stateImageList.Images["added"];

      this.compareButton.Image = this.stateImageList.Images["compare"];

      // This updates the folder trees display settings
      Redisplay();

      // Hook the application Idle event to update the UI
      Application.Idle += new EventHandler(Application_Idle);
    }
    #endregion

    #region Menu handlers
    /// <summary>
    /// Compare folders
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void compareMenuItem_Click(object sender, EventArgs e)
    {
      PerformCompare();
    }

    private void compareButton_Click(object sender, EventArgs e)
    {
      PerformCompare();
    }

    private void PerformCompare()
    {
      // First mark all items as added on both sides
      this.folderTree1.RootFolder.SetAllItemsToAdded();
      this.folderTree2.RootFolder.SetAllItemsToAdded();

      // Then compare folder 1 to folder 2
      this.folderTree1.RootFolder.CompareTo(this.folderTree2.RootFolder);
      Redisplay();
      RedisplayFolders(); // TODO: should only reset folder state!
    }

    private void syncMenuItem_Click(object sender, EventArgs e)
    {
      PerformSync();
    }

    private void syncButton_Click(object sender, EventArgs e)
    {
      PerformSync();
    }

    private void PerformSync()
    {
      PerformCopy(Options.Direction.Synchronize);
    }

    private void PerformCopy(Options.Direction direction)
    {
      // Show the synchronization options form
      using (CopyForm copyForm = new CopyForm(direction, this.folderTree1.RootFolder, this.folderTree2.RootFolder))
      {
        if (copyForm.ShowDialog(this) == DialogResult.OK)
        {
          // Build up a list of files to copy
          List<string> fromList = new List<string>();
          List<string> toList = new List<string>();
          // Also build a list of files to delete
          List<string> deleteList = new List<string>();

          Options options = copyForm.GetOptions();

          // Add the files to the list:
          AddFilesToList(this.folderTree1.RootFolder, this.folderTree2.RootFolder, options, fromList, toList, deleteList);

          if (fromList.Count == 0 && deleteList.Count == 0)
          {
            MessageBox.Show(this, "There are no files to copy or delete!", "Nothing to do", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          }
          else
          {
            string[] from = fromList.ToArray();
            string[] to = toList.ToArray();

            if (copyForm.IsPreview())
            {
              StringBuilder fromStringBuilder = new StringBuilder();
              int n = 0;
              foreach (string s in from)
              {
                fromStringBuilder.AppendLine(s + " --> " + to[n]);
                n++;
              }
              foreach (string s in deleteList)
              {
                fromStringBuilder.AppendLine("Delete: " + s);
              }

              ShowPreview(fromStringBuilder.ToString());

              //string filename = Path.GetTempFileName(); //Path.Combine(Environment.CurrentDirectory, "test.txt");
              //File.WriteAllText(filename, fromStringBuilder.ToString());
              //Process p = Process.Start("Notepad", filename);
              //File.Delete(filename);
            }
            else
            {
              bool AnyOperationsAborted = false;

              if (from.Length > 0 && !FileOperation.CopyFiles(this.Handle, from, to, "Synchronizing...", out AnyOperationsAborted))
              {
                MessageBox.Show(this, "An error occurred while copying files." + Environment.NewLine + Environment.NewLine + "Not all files were copied. Please repeat the operation.", "Error during synchronization", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
              else if (AnyOperationsAborted)
              {
                MessageBox.Show(this, "The operation was cancelled while copying files." + Environment.NewLine + Environment.NewLine + "Not all files were copied. Please repeat the operation.", "Error during synchronization", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
              else if (deleteList.Count > 0)
              {
                string[] delete = deleteList.ToArray();
                if (!FileOperation.DeleteFiles(this.Handle, delete, "Synchronizing...", out AnyOperationsAborted))
                {
                  MessageBox.Show(this, "An error occurred while deleting files." + Environment.NewLine + Environment.NewLine + "Not all necessary files were deleted. Please repeat the operation.", "Error during synchronization", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (AnyOperationsAborted)
                {
                  MessageBox.Show(this, "The operation was cancelled while deleting files." + Environment.NewLine + Environment.NewLine + "Not all necessary files were deleted. Please repeat the operation.", "Error during synchronization", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              }
              // TODO: refresh here
            }
          }
        }
      }
    }

    private void ShowPreview(string s)
    {
      using (ShowTextForm f = new ShowTextForm(s))
      {
        f.ShowDialog(this);
      }
    }

    private void AddFilesToList(FolderItem leftFolder, FolderItem rightFolder, Options options, List<string> fromList, List<string> toList, List<string> deleteList)
    {
      if (leftFolder != null && leftFolder.Files != null && (options.direction == Options.Direction.LeftToRight || options.direction == Options.Direction.Synchronize))
      {
        // Loop over the files in the left folder
        foreach (FileItem file in leftFolder.Files)
        {
          if (
            (file.State == CompareState.Added && options.addedFilesAction == Options.Action.Copy)
            || (file.State == CompareState.Newer && options.changedFilesAction == Options.Action.Copy)
            || (file.State == CompareState.Older && options.changedFilesAction == Options.Action.Delete)
          )
          {
            fromList.Add(Path.Combine(leftFolder.Name, file.Name));
            toList.Add(Path.Combine(rightFolder.Name, file.Name));
          }
          else if (
            (file.State == CompareState.Added && options.addedFilesAction == Options.Action.Delete)
            || (file.State == CompareState.Unchanged && options.unchangedFilesAction == Options.Action.Delete)
           )
          {
            deleteList.Add(Path.Combine(leftFolder.Name, file.Name));
          }
        }
      }

      if (rightFolder != null && rightFolder.Files != null && (options.direction == Options.Direction.RightToLeft || options.direction == Options.Direction.Synchronize))
      {
        // Loop over the files in the RIGHT folder
        foreach (FileItem file in rightFolder.Files)
        {
          if (
            (file.State == CompareState.Added && options.addedFilesAction == Options.Action.Copy)
            || (file.State == CompareState.Newer && options.changedFilesAction == Options.Action.Copy)
            || (file.State == CompareState.Older && options.changedFilesAction == Options.Action.Delete)
          )
          {
            fromList.Add(Path.Combine(rightFolder.Name, file.Name));
            toList.Add(Path.Combine(leftFolder.Name, file.Name));
          }
          else if (
            (file.State == CompareState.Added && options.addedFilesAction == Options.Action.Delete)
            || (file.State == CompareState.Unchanged && options.unchangedFilesAction == Options.Action.Delete)
           )
          {
            deleteList.Add(Path.Combine(rightFolder.Name, file.Name));
          }
        }
      }

      if (leftFolder != null && leftFolder.Folders != null && (options.direction == Options.Direction.LeftToRight || options.direction == Options.Direction.Synchronize))
      {
        foreach (FolderItem folder in leftFolder.Folders)
        {
          // Find the corresponding folder on the right
          FolderItem folder2 = null;
          if (rightFolder.Folders != null)
            folder2 = rightFolder.FindFolderByName(Path.GetFileName(folder.Name));
          if (folder2 == null)
            // The destination folder does not exist. Create a dummy folder for it:
            folder2 = new FolderItem(rightFolder, Path.Combine(rightFolder.Name, Path.GetFileName(folder.Name)), DateTime.Now);
          AddFilesToList(folder, folder2, options, fromList, toList, deleteList);
        }
      }

      if (rightFolder != null && rightFolder.Folders != null && (options.direction == Options.Direction.RightToLeft || options.direction == Options.Direction.Synchronize))
      {
        foreach (FolderItem folder in rightFolder.Folders)
        {
          // Find the corresponding folder on the left
          FolderItem folder2 = null;
          if (leftFolder.Folders != null)
            folder2 = leftFolder.FindFolderByName(Path.GetFileName(folder.Name));
          if (folder2 == null)
          {
            // The destination folder does not exist. Create a dummy folder for it:
            folder2 = new FolderItem(leftFolder, Path.Combine(leftFolder.Name, Path.GetFileName(folder.Name)), DateTime.Now);
          }
          AddFilesToList(folder2, folder, options, fromList, toList, deleteList);
        }
      }
    }

    private void leftToRightMenuItem_Click(object sender, EventArgs e)
    {
      PerformLeftToRightCopy();
    }

    private void leftToRightButton_Click(object sender, EventArgs e)
    {
      PerformLeftToRightCopy();
    }

    private void PerformLeftToRightCopy()
    {
      PerformCopy(Options.Direction.LeftToRight);
    }

    private void rightToLeftMenuItem_Click(object sender, EventArgs e)
    {
      PerformRightToLeftCopy();
    }

    private void rightToLeftButton_Click(object sender, EventArgs e)
    {
      PerformRightToLeftCopy();
    }

    private void PerformRightToLeftCopy()
    {
      PerformCopy(Options.Direction.RightToLeft);
    }

    /// <summary>
    /// Close the form on exit
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void exitMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    /// <summary>
    /// Redisplay when the state of a display button has changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void showAddedButton_CheckedChanged(object sender, EventArgs e)
    {
      Redisplay();
    }

    private void showNewerButton_CheckedChanged(object sender, EventArgs e)
    {
      Redisplay();
    }

    private void showOlderButton_CheckedChanged(object sender, EventArgs e)
    {
      Redisplay();
    }

    private void showEqualButton_CheckedChanged(object sender, EventArgs e)
    {
      Redisplay();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Redisplay both folder trees
    /// </summary>
    public void Redisplay()
    {
      UpdateDisplayState(this.folderTree1);
      UpdateDisplayState(this.folderTree2);

      this.folderTree1.Redisplay(true);
      this.folderTree2.Redisplay(true);
    }

    public void RedisplayFolders()
    {
      this.folderTree1.RedisplayFolders();
      this.folderTree2.RedisplayFolders();
    }

    /// <summary>
    /// Update the display state in the specified folder tree
    /// </summary>
    /// <param name="folderTree"></param>
    private void UpdateDisplayState(FolderTree folderTree)
    {
      folderTree.SetStateDisplay(CompareState.Older, this.showOlderButton.Checked);
      folderTree.SetStateDisplay(CompareState.Unchanged, this.showEqualButton.Checked);
      folderTree.SetStateDisplay(CompareState.Newer, this.showNewerButton.Checked);
      folderTree.SetStateDisplay(CompareState.Added, this.showAddedButton.Checked);
    }

    /// <summary>
    /// Update the UI. Called from Application_Idle
    /// </summary>
    public void UpdateUI()
    {
      bool bothTreesContainFolders = this.folderTree1.HasFolder && this.folderTree2.HasFolder;
      bool oneTreeContainsFolders = this.folderTree1.HasFolder || this.folderTree2.HasFolder;
      bool wasCompared = this.folderTree1.WasCompared && this.folderTree2.WasCompared;

      // Folder menu
      this.compareMenuItem.Enabled = bothTreesContainFolders;
      this.syncMenuItem.Enabled = wasCompared;
      this.leftToRightMenuItem.Enabled = wasCompared;
      this.rightToLeftMenuItem.Enabled = wasCompared;

      // View menu
      this.refreshMenuItem.Enabled = bothTreesContainFolders;

      // Toolbar
      this.showOlderButton.Enabled = wasCompared;
      this.showEqualButton.Enabled = wasCompared;
      this.showNewerButton.Enabled = wasCompared;
      this.showAddedButton.Enabled = wasCompared;

      this.compareButton.Enabled = bothTreesContainFolders;
      this.syncButton.Enabled = wasCompared;
      this.leftToRightButton.Enabled = wasCompared;
      this.rightToLeftButton.Enabled = wasCompared;
    }

    private void KeepListsInSync(FolderTree one, FolderTree two)
    {
      if (one.SelectedItem != null)
      {
        two.SelectItemWithName(Path.GetFileName(one.SelectedItem.Name));
      }
    }

    private void KeepTreesInSync(FolderTree one, FolderTree two)
    {
      FolderItem folder = one.SelectedFolder;

      if (folder != null)
      {
        if (two.SelectFolder(folder.Name.Substring(one.RootFolder.FullName().Length)))
          two.Redisplay(true);
      }
    }
    #endregion

    #region Event handlers and overrides
    // Just to make sure, we hook the application idle event to update the UI
    private void Application_Idle(object sender, EventArgs e)
    {
      UpdateUI();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      Version version = new Version(Application.ProductVersion);
      this.helpLink.Text = this.helpLink.Text.Replace("#", string.Format("v{0}.{1}.{2}", version.Major, version.Minor, version.Build));

      // Use the first two arguments on the command line to fill the folder tree controls
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length > 1)
      {
        this.folderTree1.SetRootPath(args[1]);
      }
      else
        this.folderTree1.Clear();

      if (args.Length > 2)
      {
        this.folderTree2.SetRootPath(args[2]);
        PerformCompare(); // TODO: make this a switch?
      }
      else
        this.folderTree2.Clear();
    }

    // Unhook the Appliction_Idle event handler
    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);

      Application.Idle -= new EventHandler(Application_Idle);
    }
    #endregion

    #region Foldertree event handlers
    private void folderTree1_SelectedItemChanged(object sender, EventArgs e)
    {
      if (!this.folderTree2.IsUpdatingList)
        KeepListsInSync(this.folderTree1, this.folderTree2);
    }

    private void folderTree2_SelectedItemChanged(object sender, EventArgs e)
    {
      if (!this.folderTree1.IsUpdatingList)
        KeepListsInSync(this.folderTree2, this.folderTree1);
    }

    private void folderTree1_CurrentFolderChanged(object sender, EventArgs e)
    {
      KeepTreesInSync(this.folderTree1, this.folderTree2);
    }

    private void folderTree2_CurrentFolderChanged(object sender, EventArgs e)
    {
      KeepTreesInSync(this.folderTree2, this.folderTree1);
    }
    #endregion

    private void folderTree_StatusChanged(object sender, FolderTree.StatusChangedEventArgs e)
    {
      if (e.Status == null)
        this.statusLabel.Text = "Ready.";
      else
        this.statusLabel.Text = e.Status;

      this.mainStatusStrip.Refresh();
    }

    private void helpLink_Click(object sender, EventArgs e)
    {
      using (new WaitCursor())
      {
        System.Diagnostics.Process.Start("http://www.mobzystems.com/Tools/MOBZync.aspx");
      }
    }
  }
}