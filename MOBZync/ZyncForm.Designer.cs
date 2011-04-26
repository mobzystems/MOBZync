namespace MOBZync
{
  partial class ZyncForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZyncForm));
      System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
      this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.compareMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.leftToRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rightToLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.syncMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.helpLink = new System.Windows.Forms.ToolStripStatusLabel();
      this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
      this.folderTree1 = new MOBZync.FolderTree();
      this.folderTree2 = new MOBZync.FolderTree();
      this.stateImageList = new System.Windows.Forms.ImageList(this.components);
      this.showEqualButton = new System.Windows.Forms.ToolStripButton();
      this.showOlderButton = new System.Windows.Forms.ToolStripButton();
      this.showNewerButton = new System.Windows.Forms.ToolStripButton();
      this.showAddedButton = new System.Windows.Forms.ToolStripButton();
      this.mainToolStrip = new System.Windows.Forms.ToolStrip();
      this.compareButton = new System.Windows.Forms.ToolStripButton();
      this.syncButton = new System.Windows.Forms.ToolStripButton();
      this.rightToLeftButton = new System.Windows.Forms.ToolStripButton();
      this.leftToRightButton = new System.Windows.Forms.ToolStripButton();
      toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.mainMenuStrip.SuspendLayout();
      this.mainStatusStrip.SuspendLayout();
      this.mainSplitContainer.Panel1.SuspendLayout();
      this.mainSplitContainer.Panel2.SuspendLayout();
      this.mainSplitContainer.SuspendLayout();
      this.mainToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripSeparator2
      // 
      toolStripSeparator2.Name = "toolStripSeparator2";
      toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
      // 
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
      // 
      // toolStripSeparator3
      // 
      toolStripSeparator3.Name = "toolStripSeparator3";
      toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
      // 
      // mainMenuStrip
      // 
      this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.viewToolStripMenuItem});
      this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
      this.mainMenuStrip.Name = "mainMenuStrip";
      this.mainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.mainMenuStrip.Size = new System.Drawing.Size(638, 24);
      this.mainMenuStrip.TabIndex = 0;
      this.mainMenuStrip.Text = "menuStrip1";
      // 
      // folderToolStripMenuItem
      // 
      this.folderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareMenuItem,
            toolStripSeparator3,
            this.leftToRightMenuItem,
            this.rightToLeftMenuItem,
            this.syncMenuItem,
            toolStripSeparator1,
            this.exitMenuItem});
      this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
      this.folderToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
      this.folderToolStripMenuItem.Text = "&Folder";
      // 
      // compareMenuItem
      // 
      this.compareMenuItem.Name = "compareMenuItem";
      this.compareMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
      this.compareMenuItem.Size = new System.Drawing.Size(179, 22);
      this.compareMenuItem.Text = "Compare";
      this.compareMenuItem.ToolTipText = "Compare the contents of the two folders";
      this.compareMenuItem.Click += new System.EventHandler(this.compareMenuItem_Click);
      // 
      // leftToRightMenuItem
      // 
      this.leftToRightMenuItem.Name = "leftToRightMenuItem";
      this.leftToRightMenuItem.Size = new System.Drawing.Size(179, 22);
      this.leftToRightMenuItem.Text = "Copy &left to right...";
      this.leftToRightMenuItem.Click += new System.EventHandler(this.leftToRightMenuItem_Click);
      // 
      // rightToLeftMenuItem
      // 
      this.rightToLeftMenuItem.Name = "rightToLeftMenuItem";
      this.rightToLeftMenuItem.Size = new System.Drawing.Size(179, 22);
      this.rightToLeftMenuItem.Text = "Copy &right to left...";
      this.rightToLeftMenuItem.Click += new System.EventHandler(this.rightToLeftMenuItem_Click);
      // 
      // syncMenuItem
      // 
      this.syncMenuItem.Name = "syncMenuItem";
      this.syncMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
      this.syncMenuItem.Size = new System.Drawing.Size(179, 22);
      this.syncMenuItem.Text = "Synchronize...";
      this.syncMenuItem.ToolTipText = "Synchronize the contents of the two folders";
      this.syncMenuItem.Click += new System.EventHandler(this.syncMenuItem_Click);
      // 
      // exitMenuItem
      // 
      this.exitMenuItem.Name = "exitMenuItem";
      this.exitMenuItem.Size = new System.Drawing.Size(179, 22);
      this.exitMenuItem.Text = "E&xit";
      this.exitMenuItem.ToolTipText = "Exit Zync";
      this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
      this.viewToolStripMenuItem.Text = "&View";
      // 
      // refreshMenuItem
      // 
      this.refreshMenuItem.Name = "refreshMenuItem";
      this.refreshMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
      this.refreshMenuItem.Size = new System.Drawing.Size(142, 22);
      this.refreshMenuItem.Text = "&Refresh";
      // 
      // mainStatusStrip
      // 
      this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.helpLink});
      this.mainStatusStrip.Location = new System.Drawing.Point(0, 393);
      this.mainStatusStrip.Name = "mainStatusStrip";
      this.mainStatusStrip.Size = new System.Drawing.Size(638, 22);
      this.mainStatusStrip.TabIndex = 2;
      this.mainStatusStrip.Text = "statusStrip1";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(480, 17);
      this.statusLabel.Spring = true;
      this.statusLabel.Text = "Ready.";
      this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // helpLink
      // 
      this.helpLink.ActiveLinkColor = System.Drawing.Color.Blue;
      this.helpLink.IsLink = true;
      this.helpLink.Name = "helpLink";
      this.helpLink.Size = new System.Drawing.Size(143, 17);
      this.helpLink.Text = "MOBZync # by MOBZystems";
      this.helpLink.Click += new System.EventHandler(this.helpLink_Click);
      // 
      // mainSplitContainer
      // 
      this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainSplitContainer.IsSplitterFixed = true;
      this.mainSplitContainer.Location = new System.Drawing.Point(0, 54);
      this.mainSplitContainer.Name = "mainSplitContainer";
      // 
      // mainSplitContainer.Panel1
      // 
      this.mainSplitContainer.Panel1.Controls.Add(this.folderTree1);
      // 
      // mainSplitContainer.Panel2
      // 
      this.mainSplitContainer.Panel2.Controls.Add(this.folderTree2);
      this.mainSplitContainer.Size = new System.Drawing.Size(638, 339);
      this.mainSplitContainer.SplitterDistance = 323;
      this.mainSplitContainer.TabIndex = 3;
      this.mainSplitContainer.TabStop = false;
      // 
      // folderTree1
      // 
      this.folderTree1.BuddyControl = this.folderTree2;
      this.folderTree1.CurrentFolder = null;
      this.folderTree1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.folderTree1.Location = new System.Drawing.Point(0, 0);
      this.folderTree1.Name = "folderTree1";
      this.folderTree1.Size = new System.Drawing.Size(323, 339);
      this.folderTree1.StateImageList = null;
      this.folderTree1.TabIndex = 0;
      this.folderTree1.StatusChanged += new MOBZync.FolderTree.StatusChangedEventHandler(this.folderTree_StatusChanged);
      this.folderTree1.CurrentFolderChanged += new System.EventHandler(this.folderTree1_CurrentFolderChanged);
      this.folderTree1.SelectedItemChanged += new System.EventHandler(this.folderTree2_SelectedItemChanged);
      // 
      // folderTree2
      // 
      this.folderTree2.BuddyControl = this.folderTree1;
      this.folderTree2.CurrentFolder = null;
      this.folderTree2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.folderTree2.Location = new System.Drawing.Point(0, 0);
      this.folderTree2.Name = "folderTree2";
      this.folderTree2.Size = new System.Drawing.Size(311, 339);
      this.folderTree2.StateImageList = null;
      this.folderTree2.TabIndex = 0;
      this.folderTree2.StatusChanged += new MOBZync.FolderTree.StatusChangedEventHandler(this.folderTree_StatusChanged);
      this.folderTree2.CurrentFolderChanged += new System.EventHandler(this.folderTree2_CurrentFolderChanged);
      this.folderTree2.SelectedItemChanged += new System.EventHandler(this.folderTree2_SelectedItemChanged);
      // 
      // stateImageList
      // 
      this.stateImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("stateImageList.ImageStream")));
      this.stateImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.stateImageList.Images.SetKeyName(0, "unchanged");
      this.stateImageList.Images.SetKeyName(1, "older");
      this.stateImageList.Images.SetKeyName(2, "newer");
      this.stateImageList.Images.SetKeyName(3, "added");
      this.stateImageList.Images.SetKeyName(4, "compare");
      // 
      // showEqualButton
      // 
      this.showEqualButton.Checked = true;
      this.showEqualButton.CheckOnClick = true;
      this.showEqualButton.CheckState = System.Windows.Forms.CheckState.Checked;
      this.showEqualButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.showEqualButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.showEqualButton.Name = "showEqualButton";
      this.showEqualButton.Size = new System.Drawing.Size(65, 27);
      this.showEqualButton.Text = "Unchanged";
      this.showEqualButton.ToolTipText = "Show unchanged items";
      this.showEqualButton.CheckedChanged += new System.EventHandler(this.showEqualButton_CheckedChanged);
      // 
      // showOlderButton
      // 
      this.showOlderButton.Checked = true;
      this.showOlderButton.CheckOnClick = true;
      this.showOlderButton.CheckState = System.Windows.Forms.CheckState.Checked;
      this.showOlderButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
      this.showOlderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.showOlderButton.Name = "showOlderButton";
      this.showOlderButton.Size = new System.Drawing.Size(37, 27);
      this.showOlderButton.Text = "Older";
      this.showOlderButton.ToolTipText = "Show older items";
      this.showOlderButton.CheckedChanged += new System.EventHandler(this.showOlderButton_CheckedChanged);
      // 
      // showNewerButton
      // 
      this.showNewerButton.Checked = true;
      this.showNewerButton.CheckOnClick = true;
      this.showNewerButton.CheckState = System.Windows.Forms.CheckState.Checked;
      this.showNewerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.showNewerButton.Name = "showNewerButton";
      this.showNewerButton.Size = new System.Drawing.Size(42, 27);
      this.showNewerButton.Text = "Newer";
      this.showNewerButton.ToolTipText = "Show newer items";
      this.showNewerButton.CheckedChanged += new System.EventHandler(this.showNewerButton_CheckedChanged);
      // 
      // showAddedButton
      // 
      this.showAddedButton.Checked = true;
      this.showAddedButton.CheckOnClick = true;
      this.showAddedButton.CheckState = System.Windows.Forms.CheckState.Checked;
      this.showAddedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.showAddedButton.Name = "showAddedButton";
      this.showAddedButton.Size = new System.Drawing.Size(42, 27);
      this.showAddedButton.Text = "Added";
      this.showAddedButton.ToolTipText = "Show added items";
      this.showAddedButton.CheckedChanged += new System.EventHandler(this.showAddedButton_CheckedChanged);
      // 
      // mainToolStrip
      // 
      this.mainToolStrip.CanOverflow = false;
      this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
      this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showEqualButton,
            this.showNewerButton,
            this.showAddedButton,
            this.showOlderButton,
            toolStripSeparator2,
            this.compareButton,
            toolStripSeparator4,
            this.leftToRightButton,
            this.rightToLeftButton,
            this.syncButton});
      this.mainToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.mainToolStrip.Location = new System.Drawing.Point(0, 24);
      this.mainToolStrip.MinimumSize = new System.Drawing.Size(0, 30);
      this.mainToolStrip.Name = "mainToolStrip";
      this.mainToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
      this.mainToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
      this.mainToolStrip.Size = new System.Drawing.Size(638, 30);
      this.mainToolStrip.TabIndex = 1;
      // 
      // compareButton
      // 
      this.compareButton.ImageTransparentColor = System.Drawing.Color.Transparent;
      this.compareButton.Name = "compareButton";
      this.compareButton.Size = new System.Drawing.Size(54, 27);
      this.compareButton.Text = "Compare";
      this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
      // 
      // syncButton
      // 
      this.syncButton.Image = ((System.Drawing.Image)(resources.GetObject("syncButton.Image")));
      this.syncButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.syncButton.Name = "syncButton";
      this.syncButton.Size = new System.Drawing.Size(87, 27);
      this.syncButton.Text = "Synchronize";
      this.syncButton.ToolTipText = "Synchronize by copying fles in both directions";
      this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
      // 
      // rightToLeftButton
      // 
      this.rightToLeftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.rightToLeftButton.Image = ((System.Drawing.Image)(resources.GetObject("rightToLeftButton.Image")));
      this.rightToLeftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.rightToLeftButton.Name = "rightToLeftButton";
      this.rightToLeftButton.Size = new System.Drawing.Size(23, 27);
      this.rightToLeftButton.Text = "Right to left";
      this.rightToLeftButton.ToolTipText = "Copy files from right folder to left folder";
      this.rightToLeftButton.Click += new System.EventHandler(this.rightToLeftButton_Click);
      // 
      // leftToRightButton
      // 
      this.leftToRightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.leftToRightButton.Image = ((System.Drawing.Image)(resources.GetObject("leftToRightButton.Image")));
      this.leftToRightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.leftToRightButton.Name = "leftToRightButton";
      this.leftToRightButton.Size = new System.Drawing.Size(23, 27);
      this.leftToRightButton.Text = "Left to right";
      this.leftToRightButton.ToolTipText = "Copy files from left folder to right folder";
      this.leftToRightButton.Click += new System.EventHandler(this.leftToRightButton_Click);
      // 
      // toolStripSeparator4
      // 
      toolStripSeparator4.Name = "toolStripSeparator4";
      toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
      // 
      // ZyncForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(638, 415);
      this.Controls.Add(this.mainSplitContainer);
      this.Controls.Add(this.mainStatusStrip);
      this.Controls.Add(this.mainToolStrip);
      this.Controls.Add(this.mainMenuStrip);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.mainMenuStrip;
      this.Name = "ZyncForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
      this.Text = "MOBZync";
      this.mainMenuStrip.ResumeLayout(false);
      this.mainMenuStrip.PerformLayout();
      this.mainStatusStrip.ResumeLayout(false);
      this.mainStatusStrip.PerformLayout();
      this.mainSplitContainer.Panel1.ResumeLayout(false);
      this.mainSplitContainer.Panel2.ResumeLayout(false);
      this.mainSplitContainer.ResumeLayout(false);
      this.mainToolStrip.ResumeLayout(false);
      this.mainToolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip mainMenuStrip;
    private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
    private System.Windows.Forms.StatusStrip mainStatusStrip;
    private System.Windows.Forms.SplitContainer mainSplitContainer;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private FolderTree folderTree1;
    private FolderTree folderTree2;
    private System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
    private System.Windows.Forms.ImageList stateImageList;
    private System.Windows.Forms.ToolStripMenuItem compareMenuItem;
    private System.Windows.Forms.ToolStripButton showEqualButton;
    private System.Windows.Forms.ToolStripButton showOlderButton;
    private System.Windows.Forms.ToolStripButton showNewerButton;
    private System.Windows.Forms.ToolStripButton showAddedButton;
    private System.Windows.Forms.ToolStrip mainToolStrip;
    private System.Windows.Forms.ToolStripMenuItem syncMenuItem;
    private System.Windows.Forms.ToolStripButton compareButton;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.ToolStripStatusLabel helpLink;
    private System.Windows.Forms.ToolStripButton syncButton;
    private System.Windows.Forms.ToolStripMenuItem leftToRightMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rightToLeftMenuItem;
    private System.Windows.Forms.ToolStripButton leftToRightButton;
    private System.Windows.Forms.ToolStripButton rightToLeftButton;
  }
}

