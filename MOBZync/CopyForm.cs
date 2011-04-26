using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using MOBZystems;

namespace MOBZync
{
  public partial class CopyForm : Form
  {
    private FolderItem leftFolder;
    private FolderItem rightFolder;

    public CopyForm(Options.Direction direction, FolderItem leftFolder, FolderItem rightFolder)
    {
      InitializeComponent();

      this.leftFolder = leftFolder;
      this.rightFolder = rightFolder;

      this.leftFolderTextBox.Text = this.leftFolder.FullName();
      this.rightFolderTextBox.Text = this.rightFolder.FullName();

      switch (direction)
      {
        case Options.Direction.LeftToRight:
          this.leftToRightRadioButton.Checked = true;
          break;
        case Options.Direction.RightToLeft:
          this.rightToLeftRadioButton.Checked = true;
          break;
        case Options.Direction.Synchronize:
          this.syncRadioButton.Checked = true;
          break;
        default:
          Debug.Assert(false);
          break;
      }
      Application.Idle += new EventHandler(Application_Idle);
    }

    protected override void OnClosed(EventArgs e)
    {
      base.OnClosed(e);

      Application.Idle -= new EventHandler(Application_Idle);
    }

    private void Application_Idle(object sender, EventArgs e)
    {
      this.warningDeleteAddedLabel.Visible = this.deleteAddedRadioButton.Checked;
      this.warningDeleteUnchangedLabel.Visible = this.deleteUnchangedRadioButton.Checked;
      this.warningOlderOverNewerLabel.Visible = this.olderOverNewerRadioButton.Checked;
    }

    public Options GetOptions()
    {
      Options o = new Options();

      if (this.leftToRightRadioButton.Checked)
        o.direction = Options.Direction.LeftToRight;
      else if (this.rightToLeftRadioButton.Checked)
        o.direction = Options.Direction.RightToLeft;
      else
        o.direction = Options.Direction.Synchronize;

      if (this.newerOverOlderRadioButton.Checked)
        o.changedFilesAction = Options.Action.Copy;
      else if (this.olderOverNewerRadioButton.Checked)
        o.changedFilesAction = Options.Action.Delete; // Actually: replace newer with older versions

      if (this.copyAddedRadioButton.Checked)
        o.addedFilesAction = Options.Action.Copy;
      else if (this.deleteAddedRadioButton.Checked)
        o.addedFilesAction = Options.Action.Delete;

      if (this.deleteUnchangedRadioButton.Checked)
        o.unchangedFilesAction = Options.Action.Delete;

      return o;
    }

    public bool IsPreview()
    {
      return this.previewCheckBox.Checked;
    }
  }
}